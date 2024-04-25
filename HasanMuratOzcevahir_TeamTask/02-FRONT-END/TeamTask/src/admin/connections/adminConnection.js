const ip = "localhost"
const port = ":5157"
const adress = `http://${ip}${port}`

 
const adminController = `${adress}/Admin`

const conn_ADMIN_GET_USER_LIST = `${adminController}/GetUserList`
const conn_ADMIN_REMOVE_USER = `${adminController}/RemoveUser`
const conn_ADMIN_TOGGLE_USER_CONFIRM_EMAIL = `${adminController}/ToggleConfirmUserEmail`
const conn_ADMIN_EDIT_USER = `${adminController}/EditUser`

 


export {
    conn_ADMIN_GET_USER_LIST,
    conn_ADMIN_REMOVE_USER,
    conn_ADMIN_EDIT_USER,
    conn_ADMIN_TOGGLE_USER_CONFIRM_EMAIL
}
 