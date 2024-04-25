import React from 'react'

const RightSection = ({ children }) => {
    return (
        <div className='lg:col-span-9 order-first lg:order-none relative'>
            <div className='border-2 border-slate-200 rounded-md p-2  h-full' > 
            {children}


        </div>
        </div >
    )
}

export default RightSection