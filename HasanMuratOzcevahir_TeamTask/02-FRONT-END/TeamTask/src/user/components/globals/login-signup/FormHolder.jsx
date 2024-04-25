import React from 'react'

const FormHolder = ({children}) => {
    return (
        <div className='w-full h-full col-span-2 p-2 lg:p-20 order-2'>
            <div className='z-40 flex flex-col justify-center lg:w-1/2 h-full'>
            {children}
            </div>
        </div>
    )
}

export default FormHolder