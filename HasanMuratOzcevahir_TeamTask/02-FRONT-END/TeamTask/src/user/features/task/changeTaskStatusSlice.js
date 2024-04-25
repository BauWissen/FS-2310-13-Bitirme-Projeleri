
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { conn_CHANGE_TASK_STATUS, conn_TASK_STATUS, conn_USER_GET_ASSIGNED_TASKS } from "../../connection/Connections";
import axios from "axios";
import { jsonAndCredential } from "../../connection/headerConfig";

const initialState = {
    isChanged: false,
    isLoading: false,
    error: null
}
export const changeTaskStatus = createAsyncThunk(
    'changetaskstatus/changeTaskStatus',
    async (obj) => {
        console.log(obj, "obj")

        const response = await axios.post(conn_CHANGE_TASK_STATUS, obj, jsonAndCredential)

        console.log(response, " res after")
        
        return response.data
    }
)

export const changeTaskStatusSlice = createSlice({
    name: "changetaskstatus",
    initialState,
    reducers: {
    },
    extraReducers: (builder) => {
        builder.addCase(changeTaskStatus.fulfilled, (state, action) => {
            state.isLoading = false
            console.log(action.payload, " payload")
            state.isChanged = action.payload
        })
        builder.addCase(changeTaskStatus.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(changeTaskStatus.rejected, (state, action) => {
            state.isLoading = false
            state.error = action.error.message
        })
    }
})


export default changeTaskStatusSlice.reducer