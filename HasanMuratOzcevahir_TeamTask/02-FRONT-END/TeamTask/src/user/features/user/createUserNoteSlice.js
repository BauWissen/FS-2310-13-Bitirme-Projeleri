import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_GET_USER_LIST, conn_USER_CREATE_NOTE } from "../../connection/Connections";
import { jsonAndCredential } from "../../connection/headerConfig";
import { toast } from "react-toastify";

const initialState = {

    note: null,
    isLoading: false,
    error: null
}
export const createUserNote = createAsyncThunk(
    'createusernoteslice/createUserNote',
    async (userNote) => {
        const response = (await axios.post(conn_USER_CREATE_NOTE,userNote, jsonAndCredential)).data
        console.log(response, " response after create note")

   
        return response
    }
)
const createUserNoteSlice = createSlice({
    name: 'createusernoteslice',
    initialState,
    reducers: {
    },
    extraReducers: (builder) => {
        builder.addCase(createUserNote.fulfilled, (state, action) => {
            state.isLoading = false
            if (action.payload.isSucceeded) {
                toast.success(action.payload.message)
                state.note = action.payload.data
                return
            }
            toast.error(action.payload.message)
        })
        builder.addCase(createUserNote.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(createUserNote.rejected, (state, action) => {
            state.isLoading = false

        })
    }
})


export default createUserNoteSlice.reducer