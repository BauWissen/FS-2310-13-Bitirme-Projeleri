import WorkingSpaceCardTitle from './WorkingSpaceCardTitle'
import WorkingSpaceColor from './WorkingSpaceColor'
import WorkingSpaceCommentHolder from './comment/WorkingSpaceCommentHolder'
import WorkingSpaceDataTable from './data-table/WorkingSpaceDataTable'
const WorkingSpaceCard = ({ ws }) => {
    return (
        <div className='bg-slate-50 shadow-md rounded-lg border-2 border-t-0 border-slate-300'>
            <WorkingSpaceColor color={ws.color} />
            <WorkingSpaceCardTitle title={ws.title} commentCount={ws.commentCount} taskCount={ws.taskCount} />
           <span className='p-2 bg-slate-300 w-full flex'>{ws.description}</span>
            <WorkingSpaceDataTable taskList={ws.taskList} />

            {ws.commentCount > 0 ? <WorkingSpaceCommentHolder comment={ws.comments}/> : null}
             
        </div>
    )
}

export default WorkingSpaceCard