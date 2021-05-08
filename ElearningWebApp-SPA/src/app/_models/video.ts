export interface Video {
    id: number;
    url: string;
    isfree: boolean;
    createdDate: Date;
    updateDate: Date;
    className: string;
    subjectForClassId: number;
    subjectName: string;
    chapterId: number;
    chapterName: string;
    topicName: string;
    topicId: number;
    classId: number;
    publicId: string;
}

