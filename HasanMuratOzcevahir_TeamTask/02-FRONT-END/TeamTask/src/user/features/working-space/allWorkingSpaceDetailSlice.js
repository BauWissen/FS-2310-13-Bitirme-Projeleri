
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { conn_USER_WORKING_SPACES } from "../../connection/Connections";
import axios from "axios";
import { jsonAndCredential } from "../../connection/headerConfig";

let initialState = {
    workingSpace: null,
    isLoading: false,
    error: null
}
export const getAllWorkingSpaceDetail = createAsyncThunk(
    'allworkingspacedetail/getAllWorkingSpaceDetail',
    async () => {
        const response = await axios.get(conn_USER_WORKING_SPACES,jsonAndCredential)
        return response.data.data
    }
)

export const allWorkingSpaceDetailSlice = createSlice({
    name: "allworkingspacedetail",
    initialState,
    reducers: {
    },
    extraReducers: (builder) => {
        builder.addCase(getAllWorkingSpaceDetail.fulfilled, (state, action) => {
            state.workingSpace = action.payload
    
            state.isLoading = false
        })
        builder.addCase(getAllWorkingSpaceDetail.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(getAllWorkingSpaceDetail.rejected, (state, action) => {
            state.isLoading = false
            state.error = action.error.message
        })
    },
})


export default allWorkingSpaceDetailSlice.reducer