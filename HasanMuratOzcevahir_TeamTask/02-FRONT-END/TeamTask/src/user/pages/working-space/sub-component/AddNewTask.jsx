import React, { useId, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import DatePicker, { registerLocale } from "react-datepicker";
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import { tr } from 'date-fns/locale/tr';
import "react-datepicker/dist/react-datepicker.css";
import { convertDate } from '../../../../utilities/convertDate'
import { addNewTask } from '../../../features/task/addNewTaskSlice';

registerLocale('tr', tr)
const AddNewTask = () => {
    const [selectedPriority, setselectedPriority] = useState(0)
    const options = [
        { value: "0", label: "Düşük" },
        { value: "1", label: "Orta" },
        { value: "2", label: "Yüksek" },

    ];
    const dispatch = useDispatch()
    const selectedWS = useSelector(state => state.addNewTask.ws)
    const [startDate, setStartDate] = useState(new Date())

    const handleTaskSubmit = (e) => {
        e.preventDefault()
        const { TaskName } = e.target.elements
        const taskInfo = {
            WorkSpaceId: selectedWS.id,
            TaskName: TaskName.value,
            EndDate: startDate.toISOString(),
            Priority: Number(selectedPriority)
        }
        dispatch(addNewTask(taskInfo))
        console.log(taskInfo, "taskinfo")
    }
    if (selectedWS) {
        return (
            <div>

                <div className='text-4xl flex items-center justify-center bg-orange-500 p-5 lg:mb-10' style={{ background: `linear-gradient(180deg, ${selectedWS.color}30 0%, rgba(255,255,255,1) 70%)` }}>
                    <span> {selectedWS.title}</span>

                </div>
                <form onSubmit={handleTaskSubmit} className='flex flex-col gap-5 '>
                    <div className='flex flex-col gap-4' >
                        <span className='lg:text-3xl'>Oluşturmak istediğiniz görevin adı</span>
                        <input className='w-full bg-slate-100 border border-zinc-300 rounded-md p-2 lg:p-5' name='TaskName' type='text' placeholder='Görev adı' />
                    </div>
                    <div>
                        <span className='lg:text-3xl'>Görevin önem durumunu belirtin</span>

                        <div>
                            <Dropdown  options={options} onChange={e => setselectedPriority(e.value)} placeholder="Önem derecesini seçin" />
                            <div className='text-md text-slate-400 w-full text-end'>
                                <small>seçilmezse varsayılan düşük</small>
                            </div>
                        </div>
                    </div>


                    <div className=' w-full flex flex-col justify-center items-center gap-5  bg-slate-100 p-2 rounded-md'>
                        <div>
                            <span className='lg:text-4xl'>Görevin bitiş tarihini seçin</span>
                        </div>
                        <DatePicker
                            showYearDropdown
                            showMonthDropdown
                            // withPortal
                            disabledKeyboardNavigation
                            inline
                            minDate={new Date()}
                            locale="tr"
                            dateFormat="dd / MM / YYYY"
                            selected={startDate}
                            onChange={(date) => setStartDate(date)}

                        />

                        <div className='text-md text-slate-400 w-full text-center'>
                            <small>seçilmezse varsayılan bugün : {convertDate(startDate)}</small>
                        </div>
                    </div>
                    <button type='submit'  className='bg-green-300 transition-all duration-300 hover:bg-green-400 py-5 px-2 border border-zinc-400 rounded-md'>
                        <span className='font-bold'>
                        {selectedWS.title}</span>
                        <span> çalışma alanına yeni görevi ekle</span>

                    </button>
                </form>

            </div>


        )
    }
}

export default AddNewTask