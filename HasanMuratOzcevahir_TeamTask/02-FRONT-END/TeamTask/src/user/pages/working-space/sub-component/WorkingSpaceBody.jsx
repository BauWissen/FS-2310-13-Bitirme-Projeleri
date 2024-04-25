import React from 'react'
import IconGenerator from '../../../../utilities/IconGenerator'
import { useDispatch } from 'react-redux'
import { toggleComponentVisibility } from '../../../features/component/toggleComponentSlice'
import { selectedWorkingSpace } from '../../../features/task/addNewTaskSlice'
import { selectedTaskToAssign } from '../../../features/user/getUserListSlice'

const WorkingSpaceBody = ({ workingSpace }) => {
  const handleTaskAdd = (ws) => {
    dispatch(toggleComponentVisibility({ componentName: "AddTask" }))

    dispatch(selectedWorkingSpace({ workingSpace: ws }))

  }
  const handleAsignUser = (taskTo, wospTitle,wospColor) => {

    const taskToWithSpaceName = {...taskTo, wospTitle :wospTitle, wospColor: wospColor }
 
 

    dispatch(toggleComponentVisibility({ componentName: "AssignUser" }))
    dispatch(selectedTaskToAssign({ task: taskToWithSpaceName }))

    console.log(taskToWithSpaceName, "taskto")
  }
  console.log(workingSpace, " wosp")
  const dispatch = useDispatch()
  return (
    <div className='flex flex-col gap-5 lg:gap-10'>
      {
        workingSpace.map((wosp) =>
          <div className='flex lg:flex-col gap-1  flex-wrap border-[1px] lg:border-2 px-2  py-2 lg:border-zinc-400 rounded-xl  items- items-center lg:items-stretch' key={wosp.id}>
            <div style={{ backgroundColor: `${wosp.color}30` }} className='lg:text-balance items-center flex justify-between p-1  rounded-lg' >

              <div className='flex gap-4 items-center justify-center'>
                <IconGenerator name="fa-solid fa-folder" />
                <span className='font-bold'>
                  {wosp.title}
                </span>
              </div>
              <div className='lg:flex cursor-pointer px-2 lg:px-5 py-2  text-black' onClick={() => { handleTaskAdd(wosp) }}>
                <IconGenerator name="fa-solid fa-plus" />
              </div>
            </div>

            {
              wosp.taskList.map((task) => {
                let asigned = task.isUserAssigned
                return (
                  <div onClick={() => {
                    !asigned && handleAsignUser(task, wosp.title,wosp.color)
                  }} className={`${!asigned ? 'cursor-pointer bg-rose-100' : 'bg-slate-100 '}   hover:bg-slate-300  rounded-xl border-[1px] border-slate-300 lg:border-none flex p-1 justify-between items-center gap-4 `} key={task.id}>
                    <div className='flex gap-2 items-center justify-center'>

                      {
                        asigned && <small title='Kullanıcı atanmış' className='text-green-500'>
                          <IconGenerator name="fa-solid fa-user" />
                        </small>
                      }
                      {
                        !asigned && <small title='Kullanıcı ekle' className='text-red-500 cursor-pointer'>
                          <IconGenerator name="fa-solid fa-user-plus" />
                        </small>
                      }

                      <span className='text-xs lg:text-xl'>{task.title}
                      </span>
                    </div>

                    <small className='text-slate-400 text-[12px] lg:text-sm font-light'>{task.endDate}</small>
                  </div>
                )
              })
            }  </div>

        )
      }
    </div>
  )
}

export default WorkingSpaceBody