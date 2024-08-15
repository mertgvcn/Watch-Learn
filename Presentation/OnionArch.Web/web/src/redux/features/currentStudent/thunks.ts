import { createAsyncThunk } from "@reduxjs/toolkit";
import StudentAPI from "../../../utils/APIs/StudentAPI";
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel";
import CourseAPI from "../../../utils/APIs/CourseAPI";

export const GetCoursesAttendedByCurrentStudent = createAsyncThunk<CourseViewModel[]>(
    'Student/GetCoursesAttendedByCurrentStudent',
    async () => {
        const response = await CourseAPI.GetMyCourses()
        return response.data
    }
)

export const IsCurrentStudentAttendedToCourse = createAsyncThunk<boolean, number>(
    'Student/IsCurrentStudentAttendedToCourse',
    async (courseId: number) => {
        const response = await StudentAPI.IsCurrentStudentAttendedToCourse(courseId)
        return response.data
    }
)