import React from 'react'
import IconGenerator from '../../../../utilities/IconGenerator'

const WorkingSpaceCardTitle = ({title,taskCount, commentCount}) => {
    return (
        <div className='flex justify-between bg-zinc-200 items-center p-5 border-b-[1px] border-zinc-200'>
            <span className='bg-zinc-300 font-semibold p-2 rounded-md inline-block text-3xl'>
                {title}
            </span>
            <span>Görevler {taskCount}</span>
            <div className='flex gap-2 justify-center items-center'>
                {commentCount}

                <IconGenerator name="fa-regular fa-comment" />

            </div>


        </div>
    )
}

export default WorkingSpaceCardTitle