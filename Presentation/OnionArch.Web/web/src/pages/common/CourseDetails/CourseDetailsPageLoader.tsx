import { useEffect } from 'react'
import { useParams } from 'react-router-dom'
//redux
import { useSelector } from 'react-redux'
import { useAppDispatch } from '../../../redux/app/store'
import { GetCourseById } from '../../../redux/features/course/thunks'
import { IsCurrentStudentAttendedToCourse } from '../../../redux/features/currentStudent/thunks'
import { selectCourseLoading } from '../../../redux/features/course/selectors'
import { selectStudentLoading } from '../../../redux/features/currentStudent/selectors'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CourseDetailsPage from './CourseDetailsPage'

const CourseDetailsPageLoader = () => {
    const { id } = useParams()
    const dispatch = useAppDispatch()
    
    const courseLoading = useSelector(selectCourseLoading)
    const currentStudentLoading = useSelector(selectStudentLoading)

    useEffect(() => {
        dispatch(GetCourseById(Number(id)))
        dispatch(IsCurrentStudentAttendedToCourse(Number(id)))
    }, [dispatch])

    if (courseLoading || currentStudentLoading) return (<LoadingComponent />)

    return (
        <CourseDetailsPage />
    )
}

export default CourseDetailsPageLoader