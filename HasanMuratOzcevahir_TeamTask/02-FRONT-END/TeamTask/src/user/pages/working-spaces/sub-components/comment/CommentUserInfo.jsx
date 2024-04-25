import React from 'react'

const CommentUserInfo = ({ name, date }) => {
  return (
    <div className='text-xl font-semibold border-b-[1px] lg:border-b-0 lg:border-e-4 border-slate-300 lg:py-2 lg:px-4 flex lg:flex-col justify-between items-center lg:items-start'>
      <span> {name}</span>
      <span className='text-sm font-normal text-slate-500'>
        {date}
      </span>
    </div>
  )
}

export default CommentUserInfo