import React  from 'react'

const PageHolder = ({children}) => {
  return (
    <div className='w-screen h-screen flex flex-col  items-center justify-center bg-slate-100 text-slate-600 lg:overflow-hidden relative'>
        
        {children}
    </div>
  )
}

export default PageHolder