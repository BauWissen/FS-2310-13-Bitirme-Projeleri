import React, { Children } from 'react'

const DashboardCard = ({ children, cardTitle }) => {
  return (
    <div className='border-[1px] border-slate-200 rounded-lg p-0 shadow-lg overflow-hidden'>
      <div className='bg-slate-100  mb-2 p-2 rounded-md'>{cardTitle}</div>
      <div className='px-5 py-3'>   {children}</div>
    </div>
  )
}

export default DashboardCard