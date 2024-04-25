import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_ADMIN_GET_USER_LIST } from "../connections/adminConnection";
import { jsonAndCredential } from "./../../user/connection/headerConfig";



const initialState = {
    userList:null,
    isLoading:false,
    error:null
}
export const adminGetUserList = createAsyncThunk(
    'adminGetUserListSlice/adminGetUserList',
    async()=>{
console.log("çalışyo")
        const response = (await axios.get(conn_ADMIN_GET_USER_LIST,jsonAndCredential)).data

        console.log(response , "res afet requst")
        return response
    }
)


const adminGetUserListSlice = createSlice({
    name:'adminGetUserListSlice',
    initialState,
    reducers:{},
    extraReducers:(builder)=>{
        builder.addCase(adminGetUserList.fulfilled,(state,action)=>{
            state.isLoading = false
            state.userList = action.payload.data
        })
        builder.addCase(adminGetUserList.pending,(state)=>{
            state.isLoading = true
        })
        builder.addCase(adminGetUserList.rejected,(state,action)=>{
            state.isLoading = false
            // state.error = action.payload.message
        })
    }
})


export default adminGetUserListSlice.reducer