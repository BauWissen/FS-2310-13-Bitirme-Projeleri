import React, { useEffect } from 'react'
import PageTitle from '../../components/globals/PageTitle'
import { useDispatch, useSelector } from 'react-redux'
import { getUserStats } from '../../features/user/getUserStatsSlice'
import DashboardCard from './sub-components/DashboardCard'
import UserStatsItem from './sub-components/UserStatsItem'
import { getAssignedTasks } from '../../features/task/getAssignedTasksSlice'
import UserNote from './sub-components/UserNote'
const DashboardIndex = () => {
    const dispatch = useDispatch();
    const stats = useSelector(state => state.userStats.userStats)

    useEffect(() => {


        dispatch(getUserStats())

    }, [])
    console.log(stats && stats, " stats for user")
    return (
        <div>

            <PageTitle title="Dashboard" />
            <div className='grid grid-cols-1 lg:grid-cols-3 lg:gap-5'>

                <DashboardCard cardTitle="Seninle ilgili genel bilgiler.">
                    {
                        stats && <UserStatsItem stat={stats} />
                    }
                </DashboardCard>
                <DashboardCard cardTitle="Eklediğin notlardan bazıları">
                  
                    {
                        stats &&   <UserNote noteList={stats.noteList}/> 
                    }
                </DashboardCard>
            </div>
        </div>

    )
}

export default DashboardIndex