
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { conn_USER_GET_ASSIGNED_TASKS } from "../../connection/Connections";
import axios from "axios";
import { jsonAndCredential } from "../../connection/headerConfig";

let initialState = {
    assignedTasks: null,
    isLoading: false,
    error: null
}
export const getAssignedTasks = createAsyncThunk(
    'task/getAssignedTasks',
    async () => {
        const response = (await axios.get(conn_USER_GET_ASSIGNED_TASKS, jsonAndCredential)).data
        console.log(response , " res  tasks")
       return response.data
    }
)

export const getAssignedTasksSlice = createSlice({
    name: "tasks",
    initialState,
    reducers: {
    },
    extraReducers: (builder) => {
        builder.addCase(getAssignedTasks.fulfilled, (state, action) => {
            state.isLoading = false
            state.assignedTasks = action.payload
        })
        builder.addCase(getAssignedTasks.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(getAssignedTasks.rejected, (state, action) => {
            state.isLoading = false
            state.error = action.error.message
        })
    },
})


export default getAssignedTasksSlice.reducer