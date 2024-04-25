import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { setCurrentUser } from '../../features/user/loginSlice'
import { getWorkingSpace } from '../../features/working-space/workingSpaceSlice'
import { NavLink, Outlet } from 'react-router-dom'
import LeftMenu from './sub-components/LeftMenu'
import LeftMenuItem from './sub-components/LeftMenuItem'
import TopMenu from './sub-components/TopMenu'
import IconGenerator from '../../../utilities/IconGenerator'
import AdminPanelLink from './sub-components/AdminPanelLink'

const UserDashBoard = () => {

  const dispatch = useDispatch()
  const user = useSelector((state) => state.currentUser.user)
  useEffect(() => {
    dispatch(setCurrentUser())
    dispatch(getWorkingSpace())
  }, [])

  if (user) {
    return (
      <div>
        <TopMenu user={user} />

        <div id='dashboard-holder' className='flex lg:p-5 flex-col lg:flex-row w-full'>
          <LeftMenu>

            <LeftMenuItem link="" icon="fa-solid fa-home" />
            <LeftMenuItem link="workingspace" icon="fa-solid fa-folder" />
            <LeftMenuItem link="workingspaces" icon="fa-regular fa-folder-open" />
            <LeftMenuItem link="tasks" icon="fa-solid fa-list" />

            {user.isAdmin && <AdminPanelLink />}

          </LeftMenu>
          <div className='w-full  h-full bg-white lg:p-5 pt-0 '>
            <div className='h-full   rounded-md'>
              <Outlet />
            </div>

          </div>

        </div>



      </div>
    )
  }
  else
    return (
      <div className='bg-white w-screen h-screen'>
        "LOADİNG"
      </div>
    )
}

export default UserDashBoard