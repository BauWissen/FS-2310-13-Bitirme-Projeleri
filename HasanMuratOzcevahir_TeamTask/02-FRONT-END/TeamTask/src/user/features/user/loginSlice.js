import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { conn_USER_LOGIN } from "../../connection/Connections";
import { checkCookie, setCookie } from "../../../utilities/cookieop";
import { toast } from "react-toastify";
import { loginFail, loginSuccess } from "../../../utilities/toastMessages";
import { useNavigate } from "react-router-dom";
import { jsonAndCredential } from "../../connection/headerConfig";

let initialState = {
    user: null,
    attempt: false,
    isLoading: false,
    error: null
}

export const loginRequest = createAsyncThunk(
    'user/loginRequest',
    async (userFromForm) => {
        let foundUser = null
        const response = (await axios.post(conn_USER_LOGIN, userFromForm, jsonAndCredential)).data
        const responseAdmin = (await axios.get("http://localhost:5157/auth/isuseradmin/", jsonAndCredential)).data.isAdmin

        foundUser = response.isSucceeded ? foundUser = { user: response.data, isAdmin: responseAdmin } : null

        return { foundUser, message: response.message, success: response.isSucceeded }
    }
)

export const loginSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        setCurrentUser: (state, action) => {

console.log(action, " action")
            let cookieuser = checkCookie("TTU")
            if (cookieuser === undefined || cookieuser === null || cookieuser === "") {
                if (!action.payload === "home" || action.payload === undefined) {
                    window.location.href = "/"
                }
                return
            }
            let parsedUser = JSON.parse(cookieuser)
            state.user = parsedUser
            state.isLoading = false
            state.attempt = true

        },
        setLoginAttempt: (state, att) => {

            state.attempt = att.payload
        },
        removeCurrentUser: (state) => {
            state.user = null
            state.attempt = true
            state.isLoading = false
        }
    },
    extraReducers: (builder) => {
        builder.addCase(loginRequest.fulfilled, (state, action) => {
            state.error = null
            state.isLoading = false
            if (action.payload.success) {
                state.user = action.payload.foundUser
                setCookie("TTU", JSON.stringify(action.payload.foundUser), 9000)
                toast.success(action.payload.message)
                state.attempt = !state.attempt
                return
            }
            toast.error(action.payload.message)
            state.error = action.payload.message


        })
        builder.addCase(loginRequest.pending, (state) => {
            state.isLoading = true
        })
        builder.addCase(loginRequest.rejected, (state, action) => {
            state.isLoading = false
            state.error = action.error.message
        })
    },
})

export const { setCurrentUser, setLoginAttempt, removeCurrentUser } = loginSlice.actions
export default loginSlice.reducer