import React from 'react'

const FormErrors = ({errors}) => {
  return (
    <div className='flex flex-col text-sm text-red-400'>
        {
            errors?.map((err,i)=> <span key={i}>{err}</span>)
        }



    </div>
  )
}

export default FormErrors