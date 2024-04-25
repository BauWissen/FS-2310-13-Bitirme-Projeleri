import React, { useEffect, useRef } from 'react'
import PageTitle from '../../components/globals/PageTitle'
import { useDispatch, useSelector } from 'react-redux'
import { priorityConverter } from '../../../utilities/priorityConverter'
import { getTaskStatusTypes } from '../../features/task/getTaskStatusTypesSlice'
import { changeTaskStatus } from '../../features/task/changeTaskStatusSlice'
import { getAssignedTasks } from '../../features/task/getAssignedTasksSlice'
const Tasks = () => {

  const tasks = useSelector(state => state.tasks)
  const dispatch = useDispatch()
  const taskStatusTypes = useSelector(state => state.taskStatusType)
  const isChanged = useSelector(state => state.changeTaskStatus)


  console.log(tasks, "task from taskpage")
  const handleChangeStatus = (taskId, statusId) => {
    const changeStatus = { taskId, statusId }

    console.log(changeStatus)
    dispatch(changeTaskStatus(changeStatus))

  }
  useEffect(() => {
    dispatch(getTaskStatusTypes())
  }, [])
  useEffect(() => {
    dispatch(getAssignedTasks())
  }, [isChanged])

  console.log(tasks, "tasklar")
  return (
    <div>
      <PageTitle title="Atandığın görevler" />
      <div className='grid lg:grid-cols-4 gap-2 p-2 lg:p-0'>
        {
          tasks.assignedTasks && !tasks.isLoading && tasks.assignedTasks.map((item, i) => {
            let urgency = priorityConverter(item.priority)
            return (
              <div key={item.id} className='bg-slate-50 p-4 text-3xl font-semibold rounded-md shadow-lg border-slate-300 border-[1px] items-center relative'>
               {
                item.isOver && <div className='absolute w-full h-full top-0 left-0 flex  justify-center items-center'> 
                 <span className='z-50 font-extrabold bg-slate-800 p-4 text-slate-200 rounded-xl'> SÜRESİ DOLDU</span>
                <div className='absolute w-full h-full bg-rose-400 opacity-50 top-0 left-0'>  </div>
                
                </div>
               }
                <div className='bg-gray-200 my-2'>{item.workingSpaceTitle}</div>
                <div className='flex justify-between'>
                  <span className='flex items-center'>{item.title}</span>
                  <span style={{ backgroundColor: urgency.color }} className={`border-[1px] border-slate-300 bg-red-300 rounded-full p-2 flex items-center justify-center text-lg bg-[${urgency.color}]`}>
                    {urgency.text}
                  </span>

                </div>

                <div className='flex  flex-col gap-2'>
                  {/* popover will be added */}
                  <span style={{ backgroundColor: item.status.color }}>{item.status.displayText}</span>
                  <div className='flex flex-col p-2 bg-slate-400 '> {
                    taskStatusTypes.statusList && taskStatusTypes.statusList.map(si =>

                      <span onClick={() => { handleChangeStatus(item.id, si.id) }} key={si.id} style={{ color: item.status.id === si.id && item.status.color }} className='cursor-pointer p-1 text-xl hover:bg-slate-300'>
                        {si.displayText}
                      </span>

                    )
                  }</div>
                </div>
              </div>
            )
          })
        }

      </div>


    </div>
  )
}

export default Tasks