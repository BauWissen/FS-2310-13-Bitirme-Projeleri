import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { conn_ASSIGN_USER_TO_TASK } from "../../connection/Connections";
import { jsonAndCredential } from "../../connection/headerConfig";
import axios from "axios";
import { toast } from "react-toastify";

const initialState = {
    isAssigned: false,
    isLoading: false,
    error: null
}



export const assignUserToTask = createAsyncThunk(
    'assignuser/assignUserToTask',
    async (assignInfo) => {

        const response = (await axios.post(conn_ASSIGN_USER_TO_TASK, assignInfo, jsonAndCredential)).data


        console.log(response, "res after asign")
        console.log(assignInfo, " assignInfo çalışıyor")

        return response
    }
)


const assignUserToTaskSlice = createSlice({
    name: "assignuser",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(assignUserToTask.fulfilled, (state, action) => {

            if (action.payload.isSucceeded) {
                state.isAssigned = true
                toast.info(action.payload.message)
            }

            state.isLoading = false
        })
        builder.addCase(assignUserToTask.pending, (state) => {
            state.isAssigned = false
            state.isLoading = true
         })
        builder.addCase(assignUserToTask.rejected, (state, action) => { })
    }
})

export default assignUserToTaskSlice.reducer