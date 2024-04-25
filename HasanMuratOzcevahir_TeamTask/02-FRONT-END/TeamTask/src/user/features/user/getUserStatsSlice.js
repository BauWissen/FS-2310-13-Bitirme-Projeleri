import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_USER_GET_USER_STATS } from "../../connection/Connections";
import { jsonAndCredential } from "../../connection/headerConfig";

const initialState = {
    userStats: null,
    isLoading: false,
    error: null
}

export const getUserStats = createAsyncThunk(
    'userStats/getUserStats',
    async () => {
        const response = (await axios.get(conn_USER_GET_USER_STATS, jsonAndCredential)).data

        return response.data
    }
)

export const getUserStatsSlice = createSlice({
    name: 'userStats',
    initialState,
    reducers: {
        pushNewNote: (state, action) => {

            state.userStats.noteList.push(action.payload) // no need request over over again with this
      
        }
    },
    extraReducers: (builder) => {
        builder.addCase(getUserStats.fulfilled, (state, action) => {
            state.userStats = action.payload
            state.isLoading = false
        })
        builder.addCase(getUserStats.pending, (state) => {
            state.isLoading = true

        })
        builder.addCase(getUserStats.rejected, (state, action) => {
            state.isLoading = false;


        })
    }
})
export const { pushNewNote } = getUserStatsSlice.actions

export default getUserStatsSlice.reducer