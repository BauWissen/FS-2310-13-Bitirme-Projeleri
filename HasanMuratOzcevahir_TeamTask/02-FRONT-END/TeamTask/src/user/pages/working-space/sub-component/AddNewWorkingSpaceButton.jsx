import React from 'react'
import IconGenerator from '../../../../utilities/IconGenerator'
import { useDispatch } from 'react-redux'
import { toggleComponentVisibility  } from '../../../features/component/toggleComponentSlice'

const AddNewWorkingSpaceButton = ( ) => {

    const dispatch = useDispatch()
    return (
        <div className='bg-slate-300 font-semibold  mb-5 hover:bg-slate-400 duration-300 transition-all cursor-pointer p-2 rounded-lg relative'>
            <div className='flex justify-between items-center ' onClick={()=>{
                dispatch(toggleComponentVisibility({componentName: "AddWorkingSpace"}))
            }}>
                <span>
                    Yeni çalışma alanı ekle
                </span>

                <IconGenerator name="fa-solid fa-folder-plus" />
            </div>
        </div>
    )
}

export default AddNewWorkingSpaceButton