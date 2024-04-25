import { createAsyncThunk, createReducer, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { jsonAndCredential } from "../../connection/headerConfig";
import { conn_USER_LOGOUT } from "../../connection/Connections";
import { toast } from "react-toastify";
import { removeCurrentUser } from "./loginSlice";

const initialState = {
    isLoggedOut: false,
    isLoading: false,
    error: null

}
export const logOut = createAsyncThunk(
    'logout/logOut',
    async () => {
        const response = (await axios.get(conn_USER_LOGOUT, jsonAndCredential)).data

        return response
    }
)
export const logOutSlice = createSlice({
    name: 'logout',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(logOut.fulfilled, (state, action) => {
            state.isLoading = false
            state.isLoggedOut = action.payload.isSucceeded
            if (action.payload.isSucceeded) {
                toast.info(action.payload.message)
                 
                return
            }
            toast.error(action.payload.message)
        })
        builder.addCase(logOut.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(logOut.rejected, (state, action) => {
            state.error = action.payload.message
            state.isLoading = false
        })

    }
})


export default logOutSlice.reducer