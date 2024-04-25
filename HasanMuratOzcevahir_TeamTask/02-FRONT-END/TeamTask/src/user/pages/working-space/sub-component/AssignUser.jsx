import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { getUserList } from '../../../features/user/getUserListSlice';
import { assignUserToTask } from '../../../features/task/assignUserToTaskSlice';
import IconGenerator from '../../../../utilities/IconGenerator';

const AssignUser = () => {
  const dispatch = useDispatch();
  const [searchText, setsearchText] = useState(null)
  const [selectedUser, setselectedUser] = useState({})
  const userToAssign = useSelector(state => state.getUserList)
  console.log(userToAssign, " userlist with selected task")
  useEffect(() => {
    dispatch(getUserList())
    // setselectedUser({})
  }, [userToAssign.selectedTask])
  const handleUserSearchText = (text) => {
    setsearchText(text)
    console.log("aranıyor")

  }
  const handleSearch = (u) => {
    return u.userName.includes(searchText ? searchText : null)

  }
  const handleUserAssign = () => {

    const assignInfo = {
      UserId: selectedUser.id,
      TaskId: userToAssign.selectedTask.id
    }
    dispatch(assignUserToTask(assignInfo))
    console.log(assignInfo, " asigninfo")
  }

  return (
    <div className='flex flex-col'>
      <div className='flex flex-col items-start '>
        <div className='  text-3xl p-1 pt-3 lg:p-5 mb-10 w-full flex  items-center justify-center' style={{ background: `linear-gradient(180deg, ${userToAssign.selectedTask.wospColor}30 0%, rgba(255,255,255,1) 70%)` }}>
          <div className='flex flex-col justify-center items-center gap-1 lg:gap-5 bg-slate-200 border p-2 border-slate-300 shadow-2xl bg-opacity-80 w-full lg:w-1/2  lg:p-5 rounded-lg'>

            <div className='text-center w-full'>
              <span style={{ color: userToAssign.selectedTask.wospColor }} className='text-4xl font-semibold text-slate-900'> {userToAssign.selectedTask.wospTitle} </span>

              <span className='text-slate-700'>
                {userToAssign.selectedTask.title}
              </span>
             

            </div>
            <div>
              {
                selectedUser.id && <div className='flex flex-col items-center justify-center gap-2 border border-zinc-300 p-5 rounded-xl w-full relative'>
                  <span className='text-green-400 text-5xl'
                  ><IconGenerator name="fa-solid fa-user-plus" />
                  </span>
                  <span className='text-slate-600 break-words w-full text-center'>
                    {selectedUser.id && selectedUser.userName}
                  </span>
                  <span onClick={() => { setselectedUser({}) }} className='cursor-pointer pointer-events-auto text-rose-400 absolute top-0 right-2 text-2xl'><IconGenerator name="fa-solid fa-xmark" /></span>
                </div>
              }
              <span className='text-sm text-slate-400'>
                Seçilen kullanıcı sonradan değiştirilemez.
              </span>
            </div>
          </div>
        </div>
        <button onClick={handleUserAssign} type='button' className='transition-all duration-300 hover:bg-green-400 rounded-md lg:text-3xl bg-green-300 p-4 inline-block w-full'> Kullanıcıyı seçilen göreve ata</button>
      </div>
      <div className='my-4'>
        <input type="text" placeholder='Kullanıcı ara' onChange={(e) => { handleUserSearchText(e.target.value) }} className='lg:text-2xl w-full bg-slate-100 border-2 border-green-200 p-5' />
      </div>
      <div className='p-2 lg:p-10'>
        <div className='text-2xl flex flex-wrap gap-2'>
          {userToAssign.userList && userToAssign.userList.filter(handleSearch).map(item =>
            <span onClick={() => setselectedUser(item)} key={item.id} className='break-words w-full lg:w-max border shadow-lg cursor-pointer hover:bg-green-200 transition-all duration-300 border-zinc-300 p-5 rounded-md'>
              {item.userName}
            </span>

          )}
          {!searchText && "Göreve eklemek için bir kullanıcı arayın."}
        </div>

      </div>
    </div>
  )
}

export default AssignUser