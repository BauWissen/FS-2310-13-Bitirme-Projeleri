import React from 'react'
import { addWorkingSpace } from '../../../features/working-space/addWorkingSpaceSlice'
import { useDispatch } from 'react-redux'
import { ColorPicker, useColor } from 'react-color-palette'

const AddNewWorkingSpace = () => {
    const dispatch = useDispatch()
    const [color, setColor] = useColor("rgb(170,20,80)");
    const handleAddNewWorkingSpace = (e) => {
        e.preventDefault()
        const { SpaceName, SpaceDescription } = e.target.elements
        const newWorkingSpace = {
            Title: SpaceName.value,
            Description: SpaceDescription.value,
            Color: color.hex,
            UserId: ""
        }
        dispatch(addWorkingSpace(newWorkingSpace))
    }
    return (
        <div className='w-full'>
            <div className='mb-5'><span className='text-4xl'>Çalışma alanı ekliyorsun.</span></div>
            <form onSubmit={handleAddNewWorkingSpace} className=' lg:block w-full' >
                <div className='flex flex-col gap-5'>
                    <input name='SpaceName' type='text' className='w-full rounded-md bg-gray-100 border-[1px] border-zinc-100 z-50 font-semibold capitalize lg:text-2xl placeholder:text-sm placeholder:font-normal placeholder:text-slate-400' placeholder='Çalışma alanı ismi' />

                    <input name='SpaceDescription' type='text' className='w-full rounded-md bg-gray-100 border-[1px] border-zinc-100 z-50 font-semibold capitalize lg:text-2xl placeholder:text-sm placeholder:font-normal placeholder:text-slate-400' placeholder='Çalışma alanı açıklaması' />
                </div>
                <div className='my-10 text-2xl font-semibold'>Çalışma alanı için istediğin bir renk belirle!</div>
                <small>Renk seçimi yaparken açık renkler kullanmanız önerilmez.</small>
                <ColorPicker height={200} hideAlpha={true} hideInput={true} color={color} onChange={setColor} />
                <div className='flex justify-end'>
                    <button type='submit' className='bg-blue-300 px-8 py-4 mt-2 rounded-md'>Ekle
                    </button>
                </div>
            </form>
         
        </div>
    )
}

export default AddNewWorkingSpace