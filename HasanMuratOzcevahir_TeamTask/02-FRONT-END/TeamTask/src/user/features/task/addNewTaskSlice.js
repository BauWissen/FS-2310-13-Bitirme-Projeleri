import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_USER_CREATE_TASK } from "../../connection/Connections";
import { jsonAndCredential } from "../../connection/headerConfig";
import { toast } from "react-toastify";

const initialState = {
    ws: null,
    task: null,
    isLoading: false,
    error: null
}

export const addNewTask = createAsyncThunk(
    'newtask/addNewTask',
    async (newTaskInfo) => {

        const response = (await axios.post(conn_USER_CREATE_TASK, newTaskInfo, jsonAndCredential)).data

        console.log(response, "taskadd after reqs")
        return response
    }

)


export const addNewTaskSlice = createSlice({
    name: 'newtask',
    initialState,
    reducers: {
        selectedWorkingSpace: (state, action) => {
            state.ws = action.payload.workingSpace

        }

    },
    extraReducers: (builder) => {
        builder.addCase(addNewTask.fulfilled, (state, action) => {
            console.log(state, action, " state from task")
            if (action.payload.isSucceeded) {
                toast.success(action.payload.message)
                state.task = action.payload.data
            }
            state.isLoading = false
        })
        builder.addCase(addNewTask.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(addNewTask.rejected, (state, action) => {
            // state.error = action.payload.message

        })

    }
})


export const { selectedWorkingSpace } = addNewTaskSlice.actions
export default addNewTaskSlice.reducer