const ip = "localhost"
const port = ":5157"
const adress = `http://${ip}${port}`

const userController = `${adress}/User`
const workingSpaceController = `${adress}/WorkingSpace`
const taskController = `${adress}/Task`
const taskStatusController = `${adress}/TaskStatus`
const noteController = `${adress}/Note`
const conn_TASK_STATUS = `${taskStatusController}/GetAllTaskStatusTypes`


const conn_USER_LOGIN = `${userController}/LoginUser`
const conn_USER_CREATE = `${userController}/CreateUser`
const conn_USER_LOGOUT = `${userController}/LogOutUser`
const conn_USER_CREATE_NOTE = `${noteController}/CreateNote`
const conn_USER_GET_USER_STATS = `${userController}/GetUserStats`
const conn_GET_USER_LIST = `${userController}/GetAllUsers`

const conn_USER_WORKING_SPACE = `${workingSpaceController}/GetWorkingSpaceByUserIdAsync`
const conn_USER_WORKING_SPACES = `${workingSpaceController}/GetAllWorkingSpaceDetailsByUserIdAsync`
const conn_USER_ADD_WORKING_SPACE = `${workingSpaceController}/CreateWorkingSpace`

const conn_USER_GET_ASSIGNED_TASKS = `${taskController}/GetUserAssignedTasksAsync`
const conn_CHANGE_TASK_STATUS = `${taskController}/ChangeTaskStatus`
const conn_USER_CREATE_TASK = `${taskController}/CreateNewTask`
const conn_ASSIGN_USER_TO_TASK =`${taskController}/AssignUsertoTask`


export {
    conn_GET_USER_LIST,
    conn_USER_LOGIN,
    conn_USER_CREATE_NOTE,
    conn_USER_CREATE,
    conn_USER_LOGOUT,
    conn_CHANGE_TASK_STATUS,
    conn_USER_WORKING_SPACE,
    conn_USER_WORKING_SPACES,
    conn_USER_ADD_WORKING_SPACE,
    conn_USER_GET_ASSIGNED_TASKS,
    conn_ASSIGN_USER_TO_TASK,
    conn_USER_GET_USER_STATS,
    conn_USER_CREATE_TASK,
    conn_TASK_STATUS
}
 