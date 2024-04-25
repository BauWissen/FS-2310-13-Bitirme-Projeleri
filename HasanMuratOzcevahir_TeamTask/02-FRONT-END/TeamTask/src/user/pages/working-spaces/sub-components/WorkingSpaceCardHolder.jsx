import React from 'react'

const WorkingSpaceCardHolder = ({ children }) => {
    return (
        <div className='grid grid-cols-1 lg:grid-cols-2 gap-2 lg:gap-10 items-start'>

            {children}


        </div>
    )
}

export default WorkingSpaceCardHolder