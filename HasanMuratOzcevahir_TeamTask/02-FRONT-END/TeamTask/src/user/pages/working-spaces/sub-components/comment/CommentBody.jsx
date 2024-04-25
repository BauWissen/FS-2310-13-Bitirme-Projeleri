import React, { Children } from 'react'

const CommentBody = (   {children}) => {
    return (
        <div className='bg-slate-200 p-2 m-1 rounded-md lg:border-2 border-slate-300 flex flex-col lg:flex-row gap-2 lg:gap-5 lg:items-center'>
            {children}
        </div>
    )
}

export default CommentBody