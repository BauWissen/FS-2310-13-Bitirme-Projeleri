import React from 'react'

const LeftSection = ({ children }) => {
    return (
        <div className='lg:col-span-3 order-last  lg:order-none'>
      
            <div className='text-xl flex flex-col  border-[1px] shadow-xl border-zinc-100   w-full  md:col-span-3 lg:col-span-2 pt-2 p-2  overflow-x-scroll lg:overflow-hidden  rounded-md h-max lg:h-full'>
                {children}

            </div>
        </div>
    )
}

export default LeftSection