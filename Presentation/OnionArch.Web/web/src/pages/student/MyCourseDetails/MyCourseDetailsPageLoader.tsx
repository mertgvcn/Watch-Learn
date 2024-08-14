//redux
import { useAppDispatch } from '../../../redux/app/store'
//components
import MyCourseDetailsPage from './MyCourseDetailsPage'

const MyCourseDetailsPageLoader = () => {
    const dispatch = useAppDispatch()

    return (
        <MyCourseDetailsPage />
    )
}

export default MyCourseDetailsPageLoader