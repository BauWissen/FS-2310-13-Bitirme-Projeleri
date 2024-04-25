import React, { useState } from 'react'
import { convertDate } from '../../../../utilities/convertDate'
import { useDispatch, useSelector } from 'react-redux'
import { createUserNote } from '../../../features/user/createUserNoteSlice'
import { pushNewNote } from '../../../features/user/getUserStatsSlice'
const UserNote = ({ noteList }) => {
    const stats = useSelector(state => state.userStats.userStats)

    const dispatch = useDispatch()
    const handleUserNoteSubmit = (e) => {
        e.preventDefault()
        const { Title, Content, Priority } = e.target.elements
        console.log(Title.value, Content.value, Priority.value)
        const userNote = {
            NoteTitle: Title.value,
            Content: Content.value,
            Priority: Number(Priority.value)
        }

        dispatch(createUserNote(userNote)).then((action)=>{
            dispatch(pushNewNote(action.payload.data))

        })

    }



    return (
        <div>
            {
                noteList.map(note =>
                    <div className='flex flex-col bg-slate-200 mb-2 p-2 rounded-md transition-all duration-300 hover:bg-orange-200 cursor-pointer' key={note.id}>
                        <div className='flex justify-between items-center border-b border-slate-400'>
                            <span className='text-xl  font-semibold'>{note.noteTitle}</span>

                            <div className='flex items-center gap-2'>
                                <span className='text-slate-400 text-sm'> {convertDate(note.createdDate)}</span>
                                <span style={{ backgroundColor: `#${note.priorityColor}` }} className='rounded-full w-5 h-5'> </span>

                            </div>


                        </div>
                        <div>  <span>{note.content} asd</span></div>

                    </div>
                )
            }

            <div>
                <form onSubmit={handleUserNoteSubmit} className='flex justify-between gap-2 '>
                    <input name='Title' type='text' placeholder='Not başlığı' className='w-full border-none bg-orange-100 rounded-md' />
                    <input name='Content' type='text' placeholder='Notun' className='w-full border-none bg-sky-100 rounded-md' />
                    <div className='flex gap-2 items-center'>
                        <label>
                            <input className='border-none bg-[#00bb99] p-3  checked:bg-[#00bb99] checked:p-4' name="Priority" type="radio" value="0" />
                        </label>
                        <label>
                            <input className='border-none bg-[#0099cc] p-3  checked:bg-[#0099cc] checked:p-4' name="Priority" type="radio" value="1" />
                        </label>
                        <label  >
                            <input className='border-none p-3 bg-[#ff6666] checked:bg-[#ff6666] checked:p-4' name="Priority" type="radio" value="2" />
                        </label>
                    </div>


                    <button type='submit' className='w-1/3 bg-sky-300 rounded-md'> Ekle </button>


                </form>
            </div>
        </div>
    )
}

export default UserNote