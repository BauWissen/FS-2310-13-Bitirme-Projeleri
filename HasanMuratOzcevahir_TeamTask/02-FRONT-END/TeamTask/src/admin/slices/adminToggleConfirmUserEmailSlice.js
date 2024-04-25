import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_ADMIN_REMOVE_USER, conn_ADMIN_TOGGLE_USER_CONFIRM_EMAIL } from "../connections/adminConnection";
import { jsonAndCredential } from "./../../user/connection/headerConfig";
import { toast } from "react-toastify";




const initialState = {
    isChanged: null,
    isLoading: false,
    error: null
}
export const adminToggleConfirmUserEmail = createAsyncThunk(
    'adminToggleEmail/adminToggleConfirmUserEmail',
    async (userId) => {
        console.log(userId, " from slice")
        console.log("çalışyo")
        const response = await axios.post(conn_ADMIN_TOGGLE_USER_CONFIRM_EMAIL, userId, jsonAndCredential)

        console.log(response, "res afet requst toglgleemail")
        return response.data
    }
)


const adminToggleConfirmUserEmailSlice = createSlice({
    name: 'adminToggleEmail',
    initialState,
    reducers: {
        setConfirmChanged: (state) => {
            state.isChanged = !state.isChanged
        }
    },
    extraReducers: (builder) => {
        builder.addCase(adminToggleConfirmUserEmail.fulfilled, (state, action) => {
            console.log(action, " fulfiled")
            state.isLoading = false
            state.isChanged = action.payload.isSucceeded
            if (action.payload.isSucceeded)
                toast.info(action.payload.message)
        })
        builder.addCase(adminToggleConfirmUserEmail.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(adminToggleConfirmUserEmail.rejected, (state, action) => {
            state.isLoading = false

        })
    }
})

export const {setConfirmChanged} = adminToggleConfirmUserEmailSlice.actions
export default adminToggleConfirmUserEmailSlice.reducer