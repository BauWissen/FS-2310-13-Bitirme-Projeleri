
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { conn_TASK_STATUS, conn_USER_GET_ASSIGNED_TASKS } from "../../connection/Connections";
import axios from "axios";
import { jsonAndCredential } from "../../connection/headerConfig";

let initialState = {
    statusList: null,
    isLoading: false,
    error: null
}
export const getTaskStatusTypes = createAsyncThunk(
    'taskstatustypes/getTaskStatusTypes',
    async () => {

        const response = (await axios.get(conn_TASK_STATUS, jsonAndCredential)).data

        return response
    }
)

export const getTaskStatusTypesSlice = createSlice({
    name: "taskstatustypes",
    initialState,
    reducers: {
    },
    extraReducers: (builder) => {
        builder.addCase(getTaskStatusTypes.fulfilled, (state, action) => {
            state.isLoading = false
            state.statusList = action.payload.data
        })
        builder.addCase(getTaskStatusTypes.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(getTaskStatusTypes.rejected, (state, action) => {
            state.isLoading = false
            state.error = action.error.message
        })
    },
})


export default getTaskStatusTypesSlice.reducer