
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { conn_USER_ADD_WORKING_SPACE } from "../../connection/Connections";
import axios from "axios";
import { jsonAndCredential } from "../../connection/headerConfig";

let initialState = {
    workingSpace: null,
    isLoading: false,
    error: null
}
export const addWorkingSpace = createAsyncThunk(
    'addworkingspace/addNewWorkingSpace',
    async (newWorkingSpace) => {


        const response = await axios.post(conn_USER_ADD_WORKING_SPACE, newWorkingSpace, jsonAndCredential)
        return response.data.data

    }

)

export const addWorkingSpaceSlice = createSlice({
    name: "addworkingspace",
    initialState,
    reducers: {
    },
    extraReducers: (builder) => {
        builder.addCase(addWorkingSpace.fulfilled, (state, action) => {
            state.isLoading = false
            state.workingSpace = action.payload
        })
        builder.addCase(addWorkingSpace.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(addWorkingSpace.rejected, (state, action) => {
            state.isLoading = false
            state.error = action.error.message
        })
    },
})


export default addWorkingSpaceSlice.reducer