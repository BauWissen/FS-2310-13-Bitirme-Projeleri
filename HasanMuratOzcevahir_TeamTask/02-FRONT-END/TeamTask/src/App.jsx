import React, { useEffect } from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Login from "./user/pages/log-in/Login"
import UserMain from './user/pages/main/UserMain'
import SignUp from './user/pages/sign-up/SignUp'
import WorkingSpace from './user/pages/working-space/WorkingSpace'
import WorkingSpaceDetail from './user/pages/working-space-detail/WorkingSpaceDetail'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';
import UserDashBoard from './user/pages/dashboard/UserDashBoard'
import WorkingSpaces from './user/pages/working-spaces/WorkingSpaces'
import DashboardIndex from './user/pages/dashboard/DashboardIndex'
import Tasks from './user/pages/tasks/Tasks'
import AdminApp from './admin/AdminApp'
import AdminDashboard from './admin/pages/admin-dashboard/AdminDashboard'
import AdminAllUsers from './admin/pages/admin-all-users/AdminAllUsers'
import AdminAllWorkingSpaces from './admin/pages/admin-all-workingspaces/AdminAllWorkingSpaces'
import AdminEditUser from './admin/pages/admin-edit-user/AdminEditUser'
const App = () => {



  return (
    <>

      <BrowserRouter>
        <Routes>
          <Route path='/admin' key="ADMIN" element={<AdminApp />} >
            <Route path='/admin' element={<AdminDashboard />} />
            <Route path='/admin/allusers' element={<AdminAllUsers />} />
            <Route path='/admin/edituser' element={<AdminEditUser />} />
            <Route path='/admin/allworkingspaces' element={<AdminAllWorkingSpaces />} />

          </Route>

          <Route path='/' element={<UserMain />} />
          <Route path='/dashboard' element={<UserDashBoard />} >
            <Route path='/dashboard/' element={<DashboardIndex />} />
            <Route path='/dashboard/workingspace' element={<WorkingSpace />} />
            <Route path='/dashboard/workingspaces' element={<WorkingSpaces />} />
            <Route path='/dashboard/workingspacedetail' element={<WorkingSpaceDetail />} />
            <Route path='/dashboard/tasks' element={<Tasks />} />

          </Route >
          <Route path='/login' element={<Login />} />
          <Route path='/signup' element={<SignUp />} />
          <Route path='*' element={"nopage"} />

        </Routes>

      </BrowserRouter>
      <ToastContainer autoClose={1500} closeOnClick={true} position='top-center' theme='colored' />
    </>
  )
}

export default App