import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { getAllWorkingSpaceDetail } from '../../features/working-space/allWorkingSpaceDetailSlice'
import WorkingSpaceCardHolder from './sub-components/WorkingSpaceCardHolder'
import WorkingSpaceCard from './sub-components/WorkingSpaceCard'
import PageTitle from '../../components/globals/PageTitle'
const WorkingSpaces = () => {
    const dispatch = useDispatch()
    const wsd = useSelector(state => state.allWorkingSpace)
  const isChanged = useSelector(state => state.changeTaskStatus)

    useEffect(() => {
        // if (!wsd.workingSpace)
      dispatch(getAllWorkingSpaceDetail())

    }, [isChanged])

    console.log(wsd, " wsd")
    return (
        <div>
         <PageTitle title="Bütün çalışma alanların."/>
                {
                    !wsd.isLoading ? wsd.workingSpace ?
                            <WorkingSpaceCardHolder>
                                {
                                    wsd.workingSpace.map(item => <WorkingSpaceCard key={item.id} ws={item} />)
                                }
                            </WorkingSpaceCardHolder>
 
                        :
                        <>Henüz bir çalışma alanınız bulunmamakta</>
                        :
                        <>loading</>
                }
        </div>
    )
}
export default WorkingSpaces