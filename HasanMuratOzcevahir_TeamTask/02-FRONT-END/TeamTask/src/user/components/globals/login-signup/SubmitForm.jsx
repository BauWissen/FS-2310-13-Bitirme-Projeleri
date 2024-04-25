import React from 'react'

const SubmitForm = ({ children, handleSubmit }) => {
    return (
        <form onSubmit={handleSubmit} className='flex flex-col gap-3 p-5 lg:px-14 lg:py-10 border-[1px] border-slate-200 rounded-2xl shadow-xl bg-white'>

            {children}
        </form>
    )
}

export default SubmitForm