import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { jsonAndCredential } from "../../connection/headerConfig";
import { conn_USER_CREATE } from "../../connection/Connections";
import { toast } from "react-toastify";


const initialState = {
    isCreated: false,
    isLoading: false,
    error: false
}

export const signUp = createAsyncThunk(
    'signup/signUp',
    async (userObj) => {
        const response = (await axios.post(conn_USER_CREATE, userObj, jsonAndCredential)).data



        return response
    }
)


export const signUpSlice = createSlice({
    name: "signup",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(signUp.fulfilled, (state, action) => {
            state.isLoading = false
            state.isCreated = action.payload.isSucceeded
            if (action.payload.isSucceeded) {
                toast.success(action.payload.message)
                return
            }
            toast.error(action.payload.message)


        })
        builder.addCase(signUp.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(signUp.rejected, (state, action) => {

        })
    }
})


export default signUpSlice.reducer