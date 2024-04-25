import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { jsonAndCredential } from "../../connection/headerConfig";
import axios from "axios";

const initialState = {
    isAdmin: false,
    isLoading: false,
    error: null
}


export const getIsUserAdmin = createAsyncThunk(
    "isuseradmin/getIsUserAdmin",
    async () => {
        const response = (await axios.get("http://localhost:5157/Auth/IsUserAdmin", jsonAndCredential)).data


        return response
    }
)


export const isUserAdminSlice = createSlice({
    name: "isuseradmin",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(getIsUserAdmin.fulfilled, (state, action) => {
            state.isLoading = false
            state.isAdmin = action.payload.isAdmin
        })
        builder.addCase(getIsUserAdmin.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(getIsUserAdmin.rejected, (state, action) => {
            state.isLoading = false
            // state.error = action.payload.message
        })
    }
})


export default isUserAdminSlice.reducer