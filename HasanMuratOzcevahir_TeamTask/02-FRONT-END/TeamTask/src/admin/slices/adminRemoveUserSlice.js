import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_ADMIN_REMOVE_USER } from "../connections/adminConnection";
import { jsonAndCredential } from "./../../user/connection/headerConfig";
import { toast } from "react-toastify";



 

const initialState = {
    isDeleted: false,
    isLoading: false,
    error: null
}
export const adminRemoveUser = createAsyncThunk(
    'adminremove/adminremoveuser',
    async (userId) => {
        console.log(userId, " from slice")
        console.log("çalışyo")
        const response = await axios.post(conn_ADMIN_REMOVE_USER, userId, jsonAndCredential)

        console.log(response, "res afet requst removeuser")
        return response.data
    }
)


const adminRemoveUserSlice = createSlice({
    name: 'adminremove',
    initialState,
    reducers: {
        setIsDeleted : (state)=>{
             state.isDeleted = !state.isDeleted // for refresh user list again.
        }
    },
    extraReducers: (builder) => {
        builder.addCase(adminRemoveUser.fulfilled, (state, action) => {
            console.log(action, " fulfiled")
            state.isLoading = false
            state.isDeleted = action.payload.isSucceeded
            if (action.payload.isSucceeded)
                toast.info(action.payload.message)
          

        })
        builder.addCase(adminRemoveUser.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(adminRemoveUser.rejected, (state, action) => {
            state.isLoading = false
      
        })
    }
})

export const {setIsDeleted} = adminRemoveUserSlice.actions
export default adminRemoveUserSlice.reducer