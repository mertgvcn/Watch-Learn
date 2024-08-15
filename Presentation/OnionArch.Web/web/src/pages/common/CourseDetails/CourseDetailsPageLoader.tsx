import { useEffect } from 'react'
import { useParams } from 'react-router-dom'
//redux
import { useSelector } from 'react-redux'
import { useAppDispatch } from '../../../redux/app/store'
import { IsCurrentStudentAttendedToCourse } from '../../../redux/features/student/thunks'
import { selectCoursesLoading } from '../../../redux/features/course/selectors'
import { selectIsStudentAttendedToCourseLoading } from '../../../redux/features/student/selectors'
//components
import LoadingComponent from '../../../components/LoadingComponent/LoadingComponent'
import CourseDetailsPage from './CourseDetailsPage'

const CourseDetailsPageLoader = () => {
    const { id } = useParams()
    const dispatch = useAppDispatch()

    const courseLoading = useSelector(selectCoursesLoading)
    const IsStudentAttendedToCourseLoading = useSelector(selectIsStudentAttendedToCourseLoading)

    useEffect(() => {
        //dispatch(GetCourseById(Number(id))) burası GetCourseDetailById olacak
        dispatch(IsCurrentStudentAttendedToCourse(Number(id)))
    }, [dispatch])

    if (courseLoading || IsStudentAttendedToCourseLoading) return (<LoadingComponent />)

    return (
        <CourseDetailsPage />
    )
}

export default CourseDetailsPageLoader