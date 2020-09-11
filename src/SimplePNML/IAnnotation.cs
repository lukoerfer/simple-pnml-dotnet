namespace SimplePNML
{
    /// <summary>
    /// Marks elements that are graphically represented by an annotation
    /// </summary>
    public interface IAnnotation
    {
        AnnotationGraphics Graphics { get; set; }
    }
}
