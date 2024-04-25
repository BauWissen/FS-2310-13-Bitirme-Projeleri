import React from 'react'

const FormGroup = ( {children}) => {
  return (
    <div className='flex flex-col gap-1'>
        {children}
    </div>
  )
}

export default FormGroup