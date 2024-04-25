import React from 'react'
import { priorityConverter } from '../../../../utilities/priorityConverter'

const UserStatsItem = ({ stat }) => {

    return (
        <div className='lg:text-4xl font-normal text-slate-600'>
            {/* içerik .net'ten gönderilebilir */}
            <div>
                <span>{stat.taskCount}</span><span> adet görev bulunmakta</span>

            </div>
            <div>
                <span>{stat.usersInTasksCount} </span>
                <span>göreve kişi atanmış</span>
            </div>
            <div>
                <div><span>{stat.workSpaceCount} </span><span> adet proje bulunmakta</span></div>

                <div className='flex flex-col text-sm my-2'>
                    {
                        stat.totalOfEachPriority.map(
                            (p, i) => {
                                let pc = priorityConverter(p.priorityKey)
                                return (
                                    <div key={i}>
                                        <div style={{ backgroundColor: pc.color }} className='p-2 inline-block mb-1 rounded-full w-full'> <span>{pc.text} öncelikli</span>  <span> {p.priorityCount} adet görev bulunmakta</span></div>

                                    </div>
                                )
                            })
                    }

                </div>
            </div>

        </div>
    )
}

export default UserStatsItem