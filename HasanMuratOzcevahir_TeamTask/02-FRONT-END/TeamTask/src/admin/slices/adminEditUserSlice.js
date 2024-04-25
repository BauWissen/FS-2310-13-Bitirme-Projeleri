import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_ADMIN_EDIT_USER, conn_ADMIN_GET_USER_LIST } from "../connections/adminConnection";
import { jsonAndCredential } from "./../../user/connection/headerConfig";
import { toast } from "react-toastify";



const initialState = {
    editingUser: null,
    isLoading: false,
    error: null
}
export const adminEditUser = createAsyncThunk(
    'adminedituser/adminedituser',
    async (userInfo) => {
        console.log(userInfo,"çalışyo")
        const response = (await axios.post(conn_ADMIN_EDIT_USER,userInfo, jsonAndCredential)).data

        console.log(response, "res afet requst")
        return response
    }
)


const adminEditUserSlice = createSlice({
    name: 'adminedituser',
    initialState,
    reducers: {
        
    },
    extraReducers: (builder) => {
        builder.addCase(adminEditUser.fulfilled, (state, action) => {
            state.isLoading = false
            if (action.payload.isSucceeded) {
                toast.success(action.payload.message)
                return
            }
            toast.error(action.payload.message)

        })
        builder.addCase(adminEditUser.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(adminEditUser.rejected, (state, action) => {
            state.isLoading = false
            // state.error = action.payload.message
        })
    }
})


export default adminEditUserSlice.reducer