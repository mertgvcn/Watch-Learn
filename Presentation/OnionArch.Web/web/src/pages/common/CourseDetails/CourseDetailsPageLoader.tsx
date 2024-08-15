import { useEffect } from 'react'
import { useParams } from 'react-router-dom'
//redux
import { useAppDispatch } from '../../../redux/app/store'
import { useSelector } from 'react-redux'
import { GetCourseDetailById } from '../../../redux/features/course/thunks'
import { IsCurrentStudentAttendedToCourse } from '../../../redux/features/student/thunks'
import { selectCourseDetailLoading } from '../../../redux/features/course/selectors'
import { selectIsStudentAttendedToCourseLoading } from '../../../redux/features/student/selectors'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CourseDetailsPage from './CourseDetailsPage'

const CourseDetailsPageLoader = () => {
    const { id } = useParams()
    const dispatch = useAppDispatch()

    const courseDetailLoading = useSelector(selectCourseDetailLoading)
    const IsStudentAttendedToCourseLoading = useSelector(selectIsStudentAttendedToCourseLoading)

    useEffect(() => {
        dispatch(GetCourseDetailById(Number(id)))
        dispatch(IsCurrentStudentAttendedToCourse(Number(id)))
    }, [dispatch, id])

    if (courseDetailLoading || IsStudentAttendedToCourseLoading) return (<LoadingComponent />)
    
    return (
        <CourseDetailsPage />
    )
}

export default CourseDetailsPageLoader