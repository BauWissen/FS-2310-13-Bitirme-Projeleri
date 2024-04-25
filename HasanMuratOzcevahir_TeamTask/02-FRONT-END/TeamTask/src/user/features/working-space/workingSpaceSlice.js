import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_USER_WORKING_SPACE } from "../../connection/Connections";
import { jsonAndCredential } from "../../connection/headerConfig";

let initialState = {
    workingSpace: null,
    isLoading: false,
    error: null
}
export const getWorkingSpace = createAsyncThunk(
    'workingspace/getWorkingSpace',
    async () => {

        const response = await axios.get(conn_USER_WORKING_SPACE, jsonAndCredential)

        return response.data.data
    }
)
export const workingSpaceSlice = createSlice({
    name: "workingspace",
    initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder.addCase(getWorkingSpace.fulfilled, (state, action) => {
            state.workingSpace = action.payload

            state.isLoading = false
        })
        builder.addCase(getWorkingSpace.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(getWorkingSpace.rejected, (state, action) => {
            state.isLoading = false
            state.error = action.error.message
        })
    },
})
export const { pushNewSpace } = workingSpaceSlice.actions

export default workingSpaceSlice.reducer