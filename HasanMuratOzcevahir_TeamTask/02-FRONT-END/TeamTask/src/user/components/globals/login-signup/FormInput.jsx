import React from 'react'
import FormGroup from './FormGroup'

const FormInput = ({ text, iName, pHolder, type }) => {
  return (
    <FormGroup>
      <span>{text}</span>
      <div className='w-full relative'>
        <input   name={iName} placeholder={pHolder}
          className='bg-gray-50 w-full border-[1px] p-3 ps-7 rounded-md placeholder-slate-300 duration-300 transition-all  focus:outline-1 focus:outline-orange-200 '
          type={type}
        />
        <span className='absolute right-2 text-red-500 font-bold '>*</span>
      </div>


    </FormGroup>
  )
}

export default FormInput