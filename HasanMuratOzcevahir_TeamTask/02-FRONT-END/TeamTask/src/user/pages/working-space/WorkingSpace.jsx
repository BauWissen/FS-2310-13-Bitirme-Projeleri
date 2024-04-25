import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { getWorkingSpace } from '../../features/working-space/workingSpaceSlice'
import "react-color-palette/css";
import PageTitle from '../../components/globals/PageTitle';
import WorkingSpaceBody from './sub-component/WorkingSpaceBody'
import WorkingSpaceHolder from './sub-component/WorkingSpaceHolder'
import LeftSection from './sub-component/LeftSection'
import AddNewWorkingSpaceButton from './sub-component/AddNewWorkingSpaceButton'
import RightSection from './sub-component/RightSection'
import AddNewWorkingSpace from './sub-component/AddNewWorkingSpace'
import AddNewTask from './sub-component/AddNewTask'
import AssignUser from './sub-component/AssignUser'
const WorkingSpace = () => {

    const dispatch = useDispatch()
    const ws = useSelector(state => state.workingSpace)
    const component = useSelector(state => state.toggleComponent)
    const wsAdded = useSelector(state => state.addworkingspace)
    const taskAdded = useSelector(state => state.addNewTask)
    const isUserAssigned = useSelector(state => state.assignUsertoTask)
    console.log(taskAdded)
    useEffect(() => {
        if (!ws.workingSpace)
            dispatch(getWorkingSpace())
        if (wsAdded.workingSpace)
            dispatch(getWorkingSpace())
        if (taskAdded.task)
            dispatch(getWorkingSpace())
        if (isUserAssigned.isAssigned)
            dispatch(getWorkingSpace())
//not good for best practice, will be changed. maybe today maybe 1000 years later


    }, [wsAdded.workingSpace, taskAdded.task,isUserAssigned.isAssigned])

    console.log(ws, " owrkignsiapces")


    return (

        <div>
            <PageTitle title="Çalışma Alanlarının Yönetimi" />
            <div className='grid grid-cols-1 lg:grid-cols-12 lg:gap-10'>
                <LeftSection>
                    <AddNewWorkingSpaceButton />
                    <WorkingSpaceHolder ws={ws}>
                        <WorkingSpaceBody workingSpace={ws.workingSpace} />
                    </WorkingSpaceHolder>
                </LeftSection>
                <RightSection>

                    {/* will be fixed */}

                    {component.isVisibleAddWorkingSpace && <AddNewWorkingSpace />}
                    {component.isVisibleAddTask && <AddNewTask />}
                    {component.isVisibleAssignUser && <AssignUser />}



                </RightSection>


            </div>


        </div >




    )
}

export default WorkingSpace