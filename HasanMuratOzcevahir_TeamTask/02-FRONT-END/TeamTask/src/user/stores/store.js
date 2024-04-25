import { configureStore } from '@reduxjs/toolkit'
import loginReducer from '../features/user/loginSlice'
import workingSpaceReducer from '../features/working-space/workingSpaceSlice'
import allWorkingSpaceDetailReducer from '../features/working-space/allWorkingSpaceDetailSlice'
import addWorkingSpaceReducer from '../features/working-space/addWorkingSpaceSlice'
import getAssignedTasksReducer from '../features/task/getAssignedTasksSlice'
import getUserStatsReducer from '../features/user/getUserStatsSlice'
import signUpReducer from '../features/user/signUpSlice'
import logOutReducer from '../features/user/logOutSlice'
import isUserAdminReducer from '../features/user/isUserAdminSlice'
import getTaskStatusTypesReducer from '../features/task/getTaskStatusTypesSlice'
import changeTaskStatusReducer from '../features/task/changeTaskStatusSlice'
import toggleComponentReducer from '../features/component/toggleComponentSlice'
import addNewTaskReducer from '../features/task/addNewTaskSlice'
import getUserListReducer from '../features/user/getUserListSlice'
import assignUserToTaskReducer from '../features/task/assignUserToTaskSlice'
import adminGetUserListReducer from '../../admin/slices/adminGetUserListSlice'
import adminRemoveUserReducer from '../../admin/slices/adminRemoveUserSlice'
import adminToggleConfirmUserEmailReducer from '../../admin/slices/adminToggleConfirmUserEmailSlice'
import adminEditUserReducer from '../../admin/slices/adminEditUserSlice'
import createUserNoteReducer from '../features/user/createUserNoteSlice'

export default configureStore({
  reducer: {
    //admin
    adminGetUserList: adminGetUserListReducer,
    adminRemoveUser: adminRemoveUserReducer,
    adminToggleUserEmailConfirm: adminToggleConfirmUserEmailReducer,
    adminEditUser : adminEditUserReducer,
    //user
    getUserList: getUserListReducer,
    assignUsertoTask: assignUserToTaskReducer,
    addNewTask: addNewTaskReducer,
    createUserNote: createUserNoteReducer,
    toggleComponent: toggleComponentReducer,
    signUp: signUpReducer,
    logOut: logOutReducer,
    isUserAdmin: isUserAdminReducer,
    taskStatusType: getTaskStatusTypesReducer,
    changeTaskStatus: changeTaskStatusReducer,
    currentUser: loginReducer,

    workingSpace: workingSpaceReducer,
    addworkingspace: addWorkingSpaceReducer,
    allWorkingSpace: allWorkingSpaceDetailReducer,
    tasks: getAssignedTasksReducer,
    userStats: getUserStatsReducer
  },
})