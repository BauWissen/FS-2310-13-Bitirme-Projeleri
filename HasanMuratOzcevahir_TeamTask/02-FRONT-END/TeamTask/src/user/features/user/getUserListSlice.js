import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_GET_USER_LIST } from "../../connection/Connections";
import { jsonAndCredential } from "../../connection/headerConfig";

const initialState = {
    selectedTask: null,
    userList: null,
    isLoading: false,
    error: null
}
export const getUserList = createAsyncThunk(
    'userlist/getUserList',
    async () => {
        const response = (await axios.get(conn_GET_USER_LIST, jsonAndCredential)).data
        console.log(response, " response after user list")
        return response
    }
)
const getUserListSlice = createSlice({
    name: 'userlist',
    initialState,
    reducers: {
        selectedTaskToAssign: (state, action) => {
            console.log(action.payload, " is selected inşallah")
            state.selectedTask = action.payload.task
        }
    },
    extraReducers: (builder) => {
        builder.addCase(getUserList.fulfilled, (state, action) => {
            state.userList = action.payload.data
            state.isLoading = false
        })
        builder.addCase(getUserList.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(getUserList.rejected, (state, action) => {
            state.isLoading = false

        })
    }
})

export const { selectedTaskToAssign } = getUserListSlice.actions
export default getUserListSlice.reducer