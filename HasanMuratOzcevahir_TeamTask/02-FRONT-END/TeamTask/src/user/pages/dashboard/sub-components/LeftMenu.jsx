import React from 'react'
const LeftMenu = ({ children }) => {
    return (
        <div className='flex flex-row lg:flex-col p-2 justify-start items-center border-r-[1px] h-full px-2 border-zinc-200 shadow-xl bg-slate-500 lg:me-2 w-max gap-[2px] '>
            {children}
        </div>
    )
}

export default LeftMenu