// Accord Statistics Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2014
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Statistics.Analysis
{

    using System;
    using System.Collections.ObjectModel;
    using Accord.Math;
    using Accord.Math.Decompositions;
    using Accord.Math.Comparers;


    /// <summary>
    ///   Principal component analysis (PCA) is a technique used to reduce
    ///   multidimensional data sets to lower dimensions for analysis.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///   Principal Components Analysis or the Karhunen-Loève expansion is a
    ///   classical method for dimensionality reduction or exploratory data
    ///   analysis.</para>
    /// <para>
    ///   Mathematically, PCA is a process that decomposes the covariance matrix of a matrix
    ///   into two parts: Eigenvalues and column eigenvectors, whereas Singular Value Decomposition
    ///   (SVD) decomposes a matrix per se into three parts: singular values, column eigenvectors,
    ///   and row eigenvectors. The relationships between PCA and SVD lie in that the eigenvalues 
    ///   are the square of the singular values and the column vectors are the same for both.</para>
    ///   
    /// <para>
    ///   This class uses SVD on the data set which generally gives better numerical accuracy.</para>
    ///   
    /// <para>
    ///   This class can also be bound to standard controls such as the 
    ///   <a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.aspx">DataGridView</a>
    ///   by setting their DataSource property to the analysis' <see cref="Components"/> property.</para>
    ///</remarks>
    ///
    ///<example>
    ///  <para>
    ///    The example below shows a typical usage of the analysis. However, users
    ///    often ask why the framework produces different values than other packages
    ///    such as STATA or MATLAB. After the simple introductory example below, we
    ///    will be exploring why those results are often different.</para>
    ///    
    ///  <code>
    ///  // Below is the same data used on the excellent paper "Tutorial
    ///  //   On Principal Component Analysis", by Lindsay Smith (2002).
    ///  
    ///  double[,] sourceMatrix = 
    ///  {
    ///      { 2.5,  2.4 },
    ///      { 0.5,  0.7 },
    ///      { 2.2,  2.9 },
    ///      { 1.9,  2.2 },
    ///      { 3.1,  3.0 },
    ///      { 2.3,  2.7 },
    ///      { 2.0,  1.6 },
    ///      { 1.0,  1.1 },
    ///      { 1.5,  1.6 },
    ///      { 1.1,  0.9 }
    ///  }; 
    /// 
    ///  // Creates the Principal Component Analysis of the given source
    ///  var pca = new PrincipalComponentAnalysis(sourceMatrix, AnalysisMethod.Center);
    ///    
    ///  // Compute the Principal Component Analysis
    ///  pca.Compute();
    ///    
    ///  // Creates a projection considering 80% of the information
    ///  double[,] components = pca.Transform(sourceMatrix, 0.8f, true);
    ///  </code>
    ///  
    /// 
    ///  <para>
    ///    A question often asked by users is "why my matrices have inverted
    ///    signs" or "why my results differ from [another software]". In short,
    ///    despite any differences, the results are most likely correct (unless
    ///    you firmly believe you have found a bug; in this case, please fill 
    ///    in a bug report). </para>
    ///  <para>
    ///    The example below explores, in the same steps given in Lindsay's
    ///    tutorial, anything that would cause any discrepancies between the
    ///    results given by Accord.NET and results given by other softwares.</para>
    ///    
    ///  <code>
    ///  // Reproducing Lindsay Smith's "Tutorial on Principal Component Analysis"
    ///  // using the framework's default method. The tutorial can be found online
    ///  // at http://www.sccg.sk/~haladova/principal_components.pdf
    /// 
    ///  // Step 1. Get some data
    ///  // ---------------------
    ///  
    ///  double[,] data = 
    ///  {
    ///      { 2.5,  2.4 },
    ///      { 0.5,  0.7 },
    ///      { 2.2,  2.9 },
    ///      { 1.9,  2.2 },
    ///      { 3.1,  3.0 },
    ///      { 2.3,  2.7 },
    ///      { 2.0,  1.6 },
    ///      { 1.0,  1.1 },
    ///      { 1.5,  1.6 },
    ///      { 1.1,  0.9 }
    ///  };
    ///  
    ///  
    ///  // Step 2. Subtract the mean
    ///  // -------------------------
    ///  //   Note: The framework does this automatically. By default, the framework
    ///  //   uses the "Center" method, which only subtracts the mean. However, it is
    ///  //   also possible to remove the mean *and* divide by the standard deviation
    ///  //   (thus performing the correlation method) by specifying "Standardize"
    ///  //   instead of "Center" as the AnalysisMethod.
    ///  
    ///  AnalysisMethod method = AnalysisMethod.Center; // AnalysisMethod.Standardize
    ///  
    ///  
    ///  // Step 3. Compute the covariance matrix
    ///  // -------------------------------------
    ///  //   Note: Accord.NET does not need to compute the covariance
    ///  //   matrix in order to compute PCA. The framework uses the SVD
    ///  //   method which is more numerically stable, but may require
    ///  //   more processing or memory. In order to replicate the tutorial
    ///  //   using covariance matrices, please see the next example below.
    ///  
    ///  // Create the analysis using the selected method
    ///  var pca = new PrincipalComponentAnalysis(data, method);
    ///  
    ///  // Compute it
    ///  pca.Compute();
    ///  
    ///  
    ///  // Step 4. Compute the eigenvectors and eigenvalues of the covariance matrix
    ///  // -------------------------------------------------------------------------
    ///  //   Note: Since Accord.NET uses the SVD method rather than the Eigendecomposition
    ///  //   method, the Eigenvalues are not directly available. However, it is not the
    ///  //   Eigenvalues themselves which are important, but rather their proportion:
    ///  
    ///  // Those are the expected eigenvalues, in descending order:
    ///  double[] eigenvalues = { 1.28402771, 0.0490833989 };
    ///  
    ///  // And this will be their proportion:
    ///  double[] proportion = eigenvalues.Divide(eigenvalues.Sum());
    ///  
    ///  // Those are the expected eigenvectors,
    ///  // in descending order of eigenvalues:
    ///  double[,] eigenvectors =
    ///  {
    ///      { -0.677873399, -0.735178656 },
    ///      { -0.735178656,  0.677873399 }
    ///  };
    ///  
    ///  // Now, here is the place most users get confused. The fact is that
    ///  // the Eigenvalue decomposition (EVD) is not unique, and both the SVD
    ///  // and EVD routines used by the framework produces results which are
    ///  // numerically different from packages such as STATA or MATLAB, but
    ///  // those are correct.
    ///  
    ///  // If v is an eigenvector, a multiple of this eigenvector (such as a*v, with
    ///  // a being a scalar) will also be an eigenvector. In the Lindsay case, the
    ///  // framework produces a first eigenvector with inverted signs. This is the same
    ///  // as considering a=-1 and taking a*v. The result is still correct.
    ///  
    ///  // Retrieve the first expected eigenvector
    ///  double[] v = eigenvectors.GetColumn(0);
    ///  
    ///  // Multiply by a scalar and store it back
    ///  eigenvectors.SetColumn(0, v.Multiply(-1));
    ///  
    ///  // At this point, the eigenvectors should equal the pca.ComponentMatrix,
    ///  // and the proportion vector should equal the pca.ComponentProportions up
    ///  // to the 9 decimal places shown in the tutorial.
    ///  
    ///  
    ///  // Step 5. Deriving the new data set
    ///  // ---------------------------------
    ///  
    ///  double[,] actual = pca.Transform(data);
    ///  
    ///  // transformedData shown in pg. 18
    ///  double[,] expected = new double[,]
    ///  {
    ///      {  0.827970186, -0.175115307 },
    ///      { -1.77758033,   0.142857227 },
    ///      {  0.992197494,  0.384374989 },
    ///      {  0.274210416,  0.130417207 },
    ///      {  1.67580142,  -0.209498461 },
    ///      {  0.912949103,  0.175282444 },
    ///      { -0.099109437, -0.349824698 },
    ///      { -1.14457216,   0.046417258 },
    ///      { -0.438046137,  0.017764629 },
    ///      { -1.22382056,  -0.162675287 },
    ///  };
    ///  
    ///  // At this point, the actual and expected matrices
    ///  // should be equal up to 8 decimal places.
    ///  </code>
    ///  
    /// 
    ///  <para>
    ///    Some users would like to analyze huge amounts of data. In this case,
    ///    computing the SVD directly on the data could result in memory exceptions
    ///    or excessive computing times. If your data's number of dimensions is much
    ///    less than the number of observations (i.e. your matrix have less columns
    ///    than rows) then it would be a better idea to summarize your data in the
    ///    form of a covariance or correlation matrix and compute PCA using the EVD.</para>
    ///  <para>
    ///    The example below shows how to compute the analysis with covariance
    ///    matrices only.</para>
    ///    
    ///  <code>
    ///  // Reproducing Lindsay Smith's "Tutorial on Principal Component Analysis"
    ///  // using the paper's original method. The tutorial can be found online
    ///  // at http://www.sccg.sk/~haladova/principal_components.pdf
    ///  
    ///  // Step 1. Get some data
    ///  // ---------------------
    ///  
    ///  double[,] data = 
    ///  {
    ///      { 2.5,  2.4 },
    ///      { 0.5,  0.7 },
    ///      { 2.2,  2.9 },
    ///      { 1.9,  2.2 },
    ///      { 3.1,  3.0 },
    ///      { 2.3,  2.7 },
    ///      { 2.0,  1.6 },
    ///      { 1.0,  1.1 },
    ///      { 1.5,  1.6 },
    ///      { 1.1,  0.9 }
    ///  };
    ///  
    ///  
    ///  // Step 2. Subtract the mean
    ///  // -------------------------
    ///  //   Note: The framework does this automatically 
    ///  //   when computing the covariance matrix. In this
    ///  //   step we will only compute the mean vector.
    ///  
    ///  double[] mean = Accord.Statistics.Tools.Mean(data);
    ///  
    ///  
    ///  // Step 3. Compute the covariance matrix
    ///  // -------------------------------------
    ///  
    ///  double[,] covariance = Accord.Statistics.Tools.Covariance(data, mean);
    ///  
    ///  // Create the analysis using the covariance matrix
    ///  var pca = PrincipalComponentAnalysis.FromCovarianceMatrix(mean, covariance);
    ///  
    ///  // Compute it
    ///  pca.Compute();
    ///  
    ///  
    ///  // Step 4. Compute the eigenvectors and eigenvalues of the covariance matrix
    ///  //--------------------------------------------------------------------------
    ///  
    ///  // Those are the expected eigenvalues, in descending order:
    ///  double[] eigenvalues = { 1.28402771, 0.0490833989 };
    ///  
    ///  // And this will be their proportion:
    ///  double[] proportion = eigenvalues.Divide(eigenvalues.Sum());
    ///  
    ///  // Those are the expected eigenvectors,
    ///  // in descending order of eigenvalues:
    ///  double[,] eigenvectors =
    ///  {
    ///      { -0.677873399, -0.735178656 },
    ///      { -0.735178656,  0.677873399 }
    ///  };
    ///  
    ///  // Now, here is the place most users get confused. The fact is that
    ///  // the Eigenvalue decomposition (EVD) is not unique, and both the SVD
    ///  // and EVD routines used by the framework produces results which are
    ///  // numerically different from packages such as STATA or MATLAB, but
    ///  // those are correct.
    ///  
    ///  // If v is an eigenvector, a multiple of this eigenvector (such as a*v, with
    ///  // a being a scalar) will also be an eigenvector. In the Lindsay case, the
    ///  // framework produces a first eigenvector with inverted signs. This is the same
    ///  // as considering a=-1 and taking a*v. The result is still correct.
    ///  
    ///  // Retrieve the first expected eigenvector
    ///  double[] v = eigenvectors.GetColumn(0);
    ///  
    ///  // Multiply by a scalar and store it back
    ///  eigenvectors.SetColumn(0, v.Multiply(-1));
    ///  
    ///  // At this point, the eigenvectors should equal the pca.ComponentMatrix,
    ///  // and the proportion vector should equal the pca.ComponentProportions up
    ///  // to the 9 decimal places shown in the tutorial. Moreover, unlike the
    ///  // previous example, the eigenvalues vector should also be equal to the
    ///  // property pca.Eigenvalues.
    ///  
    ///  
    ///  // Step 5. Deriving the new data set
    ///  // ---------------------------------
    ///  
    ///  double[,] actual = pca.Transform(data);
    ///  
    ///  // transformedData shown in pg. 18
    ///  double[,] expected = new double[,]
    ///  {
    ///      {  0.827970186, -0.175115307 },
    ///      { -1.77758033,   0.142857227 },
    ///      {  0.992197494,  0.384374989 },
    ///      {  0.274210416,  0.130417207 },
    ///      {  1.67580142,  -0.209498461 },
    ///      {  0.912949103,  0.175282444 },
    ///      { -0.099109437, -0.349824698 },
    ///      { -1.14457216,   0.046417258 },
    ///      { -0.438046137,  0.017764629 },
    ///      { -1.22382056,  -0.162675287 },
    ///  };
    ///  
    ///  // At this point, the actual and expected matrices
    ///  // should be equal up to 8 decimal places.
    ///  </code>
    ///</example>
    ///
    [Serializable]
    public class PrincipalComponentAnalysis : IMultivariateAnalysis, IProjectionAnalysis
    {

        private int sourceDimensions;
        private double[,] source;
        private double[,] result;

        private double[] columnMeans;
        private double[] columnStdDev;

        private double[,] eigenvectors;
        private double[] eigenvalues;
        private double[] singularValues;

        private PrincipalComponentCollection componentCollection;
        private double[] componentProportions;
        private double[] componentCumulative;

        private AnalysisMethod analysisMethod;
        private bool overwriteSourceMatrix;


        private bool onlyCovarianceMatrixAvailable;
        private double[,] covarianceMatrix;


        //---------------------------------------------


        #region Constructor


         /// <summary>
        ///   Constructs a new Principal Component Analysis.
        /// </summary>
        /// 
        /// <param name="data">The source data to perform analysis. The matrix should contain
        /// variables as columns and observations of each variable as rows.</param>
        /// <param name="method">The analysis method to perform. Default is <see cref="AnalysisMethod.Center"/>.</param>
        /// 
        public PrincipalComponentAnalysis(double[][] data, AnalysisMethod method)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (data.Length == 0)
                throw new ArgumentException("Data matrix cannot be empty.", "data");

            int cols = data[0].Length;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Length != cols)
                    throw new DimensionMismatchException("data",
                        "Matrix must be rectangular. The vector at position " + i +
                        " has a different length than other vectors");
            }

            this.Source = data.ToMatrix();
            this.analysisMethod = method;
            this.sourceDimensions = cols;
        }

        /// <summary>
        ///   Constructs a new Principal Component Analysis.
        /// </summary>
        /// 
        /// <param name="data">The source data to perform analysis. The matrix should contain
        ///   variables as columns and observations of each variable as rows.</param>
        /// <param name="method">The analysis method to perform. Default is <see cref="AnalysisMethod.Center"/>.</param>
        /// 
        public PrincipalComponentAnalysis(double[,] data, AnalysisMethod method)
        {
            if (data == null) 
                throw new ArgumentNullException("data");

            this.Source = data;
            this.analysisMethod = method;
            this.sourceDimensions = data.GetLength(1);
        }

        /// <summary>
        ///   Constructs a new Principal Component Analysis.
        /// </summary>
        /// 
        /// <param name="data">The source data to perform analysis. The matrix should contain
        /// variables as columns and observations of each variable as rows.</param>
        /// 
        public PrincipalComponentAnalysis(double[,] data)
            : this(data, AnalysisMethod.Center) { }

        /// <summary>
        ///   Constructs a new Principal Component Analysis.
        /// </summary>
        /// 
        /// <param name="data">The source data to perform analysis. The matrix should contain
        /// variables as columns and observations of each variable as rows.</param>
        /// 
        public PrincipalComponentAnalysis(double[][] data)
            : this(data, AnalysisMethod.Center) { }

        private PrincipalComponentAnalysis() { }

        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        ///   Returns the original data supplied to the analysis.
        /// </summary>
        /// 
        /// <value>The original data matrix supplied to the analysis.</value>
        /// 
        public double[,] Source
        {
            get { return this.source; }
            private set
            {
                if (value != source)
                {
                    source = value;

                    // Calculate common measures to speedup other calculations
                    this.columnMeans = Accord.Statistics.Tools.Mean(source);
                    this.columnStdDev = Accord.Statistics.Tools.StandardDeviation(source, columnMeans);
                }
            }
        }

        /// <summary>
        ///   Gets the resulting projection of the source
        ///   data given on the creation of the analysis 
        ///   into the space spawned by principal components.
        /// </summary>
        /// 
        /// <value>The resulting projection in principal component space.</value>
        /// 
        public double[,] Result
        {
            get { return this.result; }
            protected set { this.result = value; }
        }

        /// <summary>
        ///   Gets a matrix whose columns contain the principal components. Also known as the Eigenvectors or loadings matrix.
        /// </summary>
        /// 
        /// <value>The matrix of principal components.</value>
        /// 
        public double[,] ComponentMatrix
        {
            get { return this.eigenvectors; }
            protected set { this.eigenvectors = value; }
        }

        /// <summary>
        ///   Gets the Principal Components in a object-oriented structure.
        /// </summary>
        /// 
        /// <value>The collection of principal components.</value>
        /// 
        public PrincipalComponentCollection Components
        {
            get { return componentCollection; }
        }

        /// <summary>
        ///   The respective role each component plays in the data set.
        /// </summary>
        /// 
        /// <value>The component proportions.</value>
        /// 
        public double[] ComponentProportions
        {
            get { return componentProportions; }
        }

        /// <summary>
        ///   The cumulative distribution of the components proportion role. Also known
        ///   as the cumulative energy of the principal components.
        /// </summary>
        /// 
        /// <value>The cumulative proportions.</value>
        /// 
        public double[] CumulativeProportions
        {
            get { return componentCumulative; }
        }

        /// <summary>
        ///   Provides access to the Singular Values stored during the analysis.
        ///   If a covariance method is chosen, then it will contain an empty vector.
        /// </summary>
        /// 
        /// <value>The singular values.</value>
        /// 
        public double[] SingularValues
        {
            get { return singularValues; }
            protected set { singularValues = value; }
        }

        /// <summary>
        ///   Provides access to the Eigenvalues stored during the analysis.
        /// </summary>
        /// 
        /// <value>The Eigenvalues.</value>
        /// 
        public double[] Eigenvalues
        {
            get { return eigenvalues; }
            protected set { eigenvalues = value; }
        }

        /// <summary>
        ///   Gets the column standard deviations of the source data given at method construction.
        /// </summary>
        /// 
        public double[] StandardDeviations
        {
            get { return this.columnStdDev; }
        }

        /// <summary>
        ///   Gets the column mean of the source data given at method construction.
        /// </summary>
        /// 
        public double[] Means
        {
            get { return this.columnMeans; }
        }

        /// <summary>
        ///   Gets or sets the method used by this analysis.
        /// </summary>
        /// 
        public AnalysisMethod Method
        {
            get { return this.analysisMethod; }
            set { this.analysisMethod = value; }
        }

        /// <summary>
        ///   Gets or sets whether calculations will be performed overwriting
        ///   data in the original source matrix, using less memory.
        /// </summary>
        /// 
        public bool Overwrite
        {
            get { return overwriteSourceMatrix; }
            set { overwriteSourceMatrix = value; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods

        /// <summary>
        ///   Computes the Principal Component Analysis algorithm.
        /// </summary>
        /// 
        public virtual void Compute()
        {
            if (!onlyCovarianceMatrixAvailable)
            {
                int rows = source.GetLength(0);

                // Center and standardize the source matrix
                double[,] matrix = Adjust(source, overwriteSourceMatrix);


                // Perform the Singular Value Decomposition (SVD) of the matrix
                SingularValueDecomposition svd = new SingularValueDecomposition(matrix,
                    computeLeftSingularVectors: true,
                    computeRightSingularVectors: true,
                    autoTranspose: true,
                    inPlace: true);

                singularValues = svd.Diagonal;

                //  The principal components of 'Source' are the eigenvectors of Cov(Source). Thus if we
                //  calculate the SVD of 'matrix' (which is Source standardized), the columns of matrix V
                //  (right side of SVD) will be the principal components of Source.                        

                // The right singular vectors contains the principal components of the data matrix
                eigenvectors = svd.RightSingularVectors;

                // The left singular vectors contains the factor scores for the principal components
                result = svd.LeftSingularVectors.MultiplyByDiagonal(singularValues);

                // Eigenvalues are the square of the singular values
                eigenvalues = new double[singularValues.Length];
                for (int i = 0; i < singularValues.Length; i++)
                    eigenvalues[i] = singularValues[i] * singularValues[i] / (rows - 1);
            }
            else
            {
                // We only have the covariance matrix. Compute the Eigenvalue decomposition
                EigenvalueDecomposition evd = new EigenvalueDecomposition(covarianceMatrix, assumeSymmetric: true);

                // Gets the Eigenvalues and corresponding Eigenvectors
                eigenvalues = evd.RealEigenvalues;
                eigenvectors = evd.Eigenvectors;
                singularValues = new double[eigenvalues.Length];

                // Sort eigenvalues and vectors in descending order
                eigenvectors = Matrix.Sort(eigenvalues, eigenvectors,
                    new GeneralComparer(ComparerDirection.Descending, true));
            }


            // Computes additional information about the analysis and creates the
            //  object-oriented structure to hold the principal components found.
            CreateComponents();
        }


        /// <summary>
        ///   Projects a given matrix into principal component space.
        /// </summary>
        /// 
        /// <param name="data">The matrix to be projected.</param>
        /// 
        public double[,] Transform(double[,] data)
        {
            return this.Transform(data, componentCollection.Count);
        }

        /// <summary>
        ///   Projects a given matrix into principal component space.
        /// </summary>
        /// 
        /// <param name="data">The matrix to be projected.</param>
        /// 
        public double[] Transform(double[] data)
        {
            return this.Transform(data, componentCollection.Count);
        }

        /// <summary>
        ///   Projects a given matrix into principal component space.
        /// </summary>
        /// 
        /// <param name="data">The matrix to be projected.</param>
        /// 
        public double[][] Transform(params double[][] data)
        {
            return this.Transform(data, componentCollection.Count);
        }

        /// <summary>
        ///   Projects a given matrix into principal component space.
        /// </summary>
        /// 
        /// <param name="data">The matrix to be projected.</param>
        /// <param name="dimensions">The number of components to consider.</param>
        /// 
        public virtual double[,] Transform(double[,] data, int dimensions)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (eigenvectors == null)
                throw new InvalidOperationException("The analysis must have been computed first.");

            if (data.GetLength(1) != sourceDimensions)
                throw new DimensionMismatchException("data",
                    "The input data should have the same number of columns as the original data.");

            if (dimensions < 0 || dimensions > Components.Count)
            {
                throw new ArgumentOutOfRangeException("dimensions",
                    "The specified number of dimensions must be equal or less than the " +
                    "number of components available in the Components collection property.");
            }

            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            // Center the data
            data = Adjust(data, false);

            // multiply the data matrix by the selected eigenvectors
            // TODO: Use cache-friendly multiplication
            double[,] r = new double[rows, dimensions];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < dimensions; j++)
                    for (int k = 0; k < cols; k++)
                        r[i, j] += data[i, k] * eigenvectors[k, j];

            return r;
        }

        /// <summary>
        ///   Projects a given matrix into principal component space.
        /// </summary>
        /// 
        /// <param name="data">The matrix to be projected.</param>
        /// <param name="dimensions">The number of components to consider.</param>
        /// 
        public double[] Transform(double[] data, int dimensions)
        {
            return Transform(new double[][] { data }, dimensions)[0];
        }

        /// <summary>
        ///   Projects a given matrix into principal component space.
        /// </summary>
        /// 
        /// <param name="data">The matrix to be projected.</param>
        /// <param name="dimensions">The number of components to consider.</param>
        /// 
        public double[][] Transform(double[][] data, int dimensions)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (eigenvectors == null)
                throw new InvalidOperationException("The analysis must have been computed first.");

            if (data[0].Length != sourceDimensions)
                throw new DimensionMismatchException("data",
                    "The input data should have the same number of columns as the original data.");

            if (dimensions < 0 || dimensions > Components.Count)
            {
                throw new ArgumentOutOfRangeException("dimensions",
                    "The specified number of dimensions must be equal or less than the " +
                    "number of components available in the Components collection property.");
            }

            int rows = data.Length;
            int cols = data[0].Length;

            // Center the data
            data = Adjust(data, false);

            // multiply the data matrix by the selected eigenvectors
            // TODO: Use cache-friendly multiplication
            double[][] r = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                r[i] = new double[dimensions];
                for (int j = 0; j < dimensions; j++)
                    for (int k = 0; k < cols; k++)
                        r[i][j] += data[i][k] * eigenvectors[k, j];
            }

            return r;
        }


        /// <summary>
        ///   Reverts a set of projected data into it's original form. Complete reverse
        ///   transformation is only possible if all components are present, and, if the
        ///   data has been standardized, the original standard deviation and means of
        ///   the original matrix are known.
        /// </summary>
        /// 
        /// <param name="data">The pca transformed data.</param>
        /// 
        public virtual double[,] Revert(double[,] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            int components = componentCollection.Count;
            double[,] reversion = new double[rows, components];


            // Revert the data (reversion = data * eigenVectors.Transpose())
            for (int i = 0; i < components; i++)
                for (int j = 0; j < rows; j++)
                    for (int k = 0; k < cols; k++)
                        reversion[j, i] += data[j, k] * eigenvectors[i, k];


            // if the data has been standardized or centered,
            //  we need to revert those operations as well
            if (this.analysisMethod == AnalysisMethod.Standardize)
            {
                // multiply by standard deviation and add the mean
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < components; j++)
                        reversion[i, j] = (reversion[i, j] * columnStdDev[j]) + columnMeans[j];
            }
            else
            {
                // only add the mean
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < components; j++)
                        reversion[i, j] = reversion[i, j] + columnMeans[j];
            }

            return reversion;
        }


        /// <summary>
        ///   Returns the minimal number of principal components
        ///   required to represent a given percentile of the data.
        /// </summary>
        /// 
        /// <param name="threshold">The percentile of the data requiring representation.</param>
        /// <returns>The minimal number of components required.</returns>
        /// 
        public int GetNumberOfComponents(float threshold)
        {
            if (threshold < 0 || threshold > 1.0)
                throw new ArgumentException("Threshold should be a value between 0 and 1", "threshold");

            for (int i = 0; i < componentCumulative.Length; i++)
            {
                if (componentCumulative[i] >= threshold)
                    return i + 1;
            }

            return componentCumulative.Length;
        }

        #endregion


        //---------------------------------------------


        #region Protected Methods
        /// <summary>
        ///   Adjusts a data matrix, centering and standardizing its values
        ///   using the already computed column's means and standard deviations.
        /// </summary>
        /// 
        protected internal double[,] Adjust(double[,] matrix, bool inPlace)
        {

            // Center the data around the mean. Will have no effect if
            //  the data is already centered (the mean will be zero).
            double[,] result = matrix.Center(columnMeans, inPlace);

            // Check if we also have to standardize our data (convert to Z Scores).
            if (this.analysisMethod == AnalysisMethod.Standardize)
            {
                for (int j = 0; j < columnStdDev.Length; j++)
                    if (columnStdDev[j] == 0)
                        throw new ArithmeticException("Standard deviation cannot be" +
                        " zero (cannot standardize the constant variable at column index " + j + ").");

                // Yes. Divide by standard deviation
                result.Standardize(columnStdDev, true);
            }

            return result;
        }

        /// <summary>
        ///   Adjusts a data matrix, centering and standardizing its values
        ///   using the already computed column's means and standard deviations.
        /// </summary>
        /// 
        protected internal double[][] Adjust(double[][] matrix, bool inPlace)
        {

            // Center the data around the mean. Will have no effect if
            //  the data is already centered (the mean will be zero).
            double[][] result = matrix.Center(columnMeans, inPlace);

            // Check if we also have to standardize our data (convert to Z Scores).
            if (this.analysisMethod == AnalysisMethod.Standardize)
            {
                for (int j = 0; j < columnStdDev.Length; j++)
                    if (columnStdDev[j] == 0) 
                        throw new ArithmeticException("Standard deviation cannot be" +
                        " zero (cannot standardize the constant variable at column index " + j + ").");

                // Yes. Divide by standard deviation
                result.Standardize(columnStdDev, true);
            }

            return result;
        }


        /// <summary>
        ///   Creates additional information about principal components.
        /// </summary>
        /// 
        protected void CreateComponents()
        {
            int numComponents = singularValues.Length;
            componentProportions = new double[numComponents];
            componentCumulative = new double[numComponents];

            // Calculate proportions
            double sum = 0.0;
            for (int i = 0; i < numComponents; i++)
                sum += System.Math.Abs(eigenvalues[i]);
            sum = (sum == 0) ? 0.0 : (1.0 / sum);

            for (int i = 0; i < numComponents; i++)
                componentProportions[i] = System.Math.Abs(eigenvalues[i]) * sum;

            // Calculate cumulative proportions
            this.componentCumulative[0] = this.componentProportions[0];
            for (int i = 1; i < this.componentCumulative.Length; i++)
                this.componentCumulative[i] = this.componentCumulative[i - 1] + this.componentProportions[i];

            // Creates the object-oriented structure to hold the principal components
            PrincipalComponent[] components = new PrincipalComponent[singularValues.Length];
            for (int i = 0; i < components.Length; i++)
                components[i] = new PrincipalComponent(this, i);
            this.componentCollection = new PrincipalComponentCollection(components);
        }
        #endregion


        #region Named Constructors
        /// <summary>
        ///   Constructs a new Principal Component Analysis from a Covariance matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   This method may be more suitable to high dimensional problems in which
        ///   the original data matrix may not fit in memory but the covariance matrix
        ///   will.</remarks>
        ///   
        /// <param name="mean">The mean vector for the source data.</param>
        /// <param name="covariance">The covariance matrix of the data.</param>
        /// 
        public static PrincipalComponentAnalysis FromCovarianceMatrix(double[] mean, double[,] covariance)
        {
            if (mean == null) throw new ArgumentNullException("mean");
            if (covariance == null) throw new ArgumentNullException("covariance");

            if (covariance.GetLength(0) != covariance.GetLength(1))
                throw new NonSymmetricMatrixException("Covariance matrix must be symmetric");

            PrincipalComponentAnalysis pca = new PrincipalComponentAnalysis();

            pca.columnMeans = mean;
            pca.covarianceMatrix = covariance;
            pca.analysisMethod = AnalysisMethod.Center;
            pca.onlyCovarianceMatrixAvailable = true;
            pca.sourceDimensions = covariance.GetLength(0);

            return pca;
        }



        /// <summary>
        ///   Constructs a new Principal Component Analysis from a Correlation matrix.
        /// </summary>
        /// 
        /// <remarks>
        ///   This method may be more suitable to high dimensional problems in which
        ///   the original data matrix may not fit in memory but the covariance matrix
        ///   will.</remarks>
        /// 
        /// <param name="mean">The mean vector for the source data.</param>
        /// <param name="stdDev">The standard deviation vectors for the source data.</param>
        /// <param name="correlation">The correlation matrix of the data.</param>
        /// 
        public static PrincipalComponentAnalysis FromCorrelationMatrix(double[] mean, double[] stdDev, double[,] correlation)
        {
            if (mean == null) throw new ArgumentNullException("mean");
            if (stdDev == null) throw new ArgumentNullException("stdDev");
            if (correlation == null) throw new ArgumentNullException("correlation");

            if (correlation.GetLength(0) != correlation.GetLength(1))
                throw new NonSymmetricMatrixException("Correlation matrix must be symmetric");

            PrincipalComponentAnalysis pca = new PrincipalComponentAnalysis();

            pca.columnMeans = mean;
            pca.columnStdDev = stdDev;
            pca.covarianceMatrix = correlation;
            pca.analysisMethod = AnalysisMethod.Standardize;
            pca.onlyCovarianceMatrixAvailable = true;
            pca.sourceDimensions = correlation.GetLength(0);

            return pca;
        }
        #endregion

    }


    #region Support Classes
    /// <summary>
    /// <para>
    ///   Represents a Principal Component found in the Principal Component Analysis,
    ///   allowing it to be bound to controls like the DataGridView. </para>
    /// <para>
    ///   This class cannot be instantiated.</para>   
    /// </summary>
    /// 
    [Serializable]
    public class PrincipalComponent : IAnalysisComponent
    {

        private int index;
        private PrincipalComponentAnalysis principalComponentAnalysis;


        /// <summary>
        ///   Creates a principal component representation.
        /// </summary>
        /// 
        /// <param name="analysis">The analysis to which this component belongs.</param>
        /// <param name="index">The component index.</param>
        /// 
        internal PrincipalComponent(PrincipalComponentAnalysis analysis, int index)
        {
            this.index = index;
            this.principalComponentAnalysis = analysis;
        }


        /// <summary>
        ///   Gets the Index of this component on the original analysis principal component collection.
        /// </summary>
        /// 
        public int Index
        {
            get { return this.index; }
        }

        /// <summary>
        ///   Returns a reference to the parent analysis object.
        /// </summary>
        /// 
        public PrincipalComponentAnalysis Analysis
        {
            get { return this.principalComponentAnalysis; }
        }

        /// <summary>
        ///   Gets the proportion of data this component represents.
        /// </summary>
        /// 
        public double Proportion
        {
            get { return this.principalComponentAnalysis.ComponentProportions[index]; }
        }

        /// <summary>
        ///   Gets the cumulative proportion of data this component represents.
        /// </summary>
        /// 
        public double CumulativeProportion
        {
            get { return this.principalComponentAnalysis.CumulativeProportions[index]; }
        }

        /// <summary>
        ///   If available, gets the Singular Value of this component found during the Analysis.
        /// </summary>
        /// 
        public double SingularValue
        {
            get { return this.principalComponentAnalysis.SingularValues[index]; }
        }

        /// <summary>
        ///   Gets the Eigenvalue of this component found during the analysis.
        /// </summary>
        /// 
        public double Eigenvalue
        {
            get { return this.principalComponentAnalysis.Eigenvalues[index]; }
        }

        /// <summary>
        ///   Gets the Eigenvector of this component.
        /// </summary>
        /// 
        public double[] Eigenvector
        {
            get
            {
                double[] eigv = new double[principalComponentAnalysis.ComponentMatrix.GetLength(0)];

                for (int i = 0; i < eigv.Length; i++)
                    eigv[i] = principalComponentAnalysis.ComponentMatrix[i, index];
                return eigv;
            }
        }
    }

    /// <summary>
    ///   Represents a Collection of Principal Components found in the 
    ///   <see cref="PrincipalComponentAnalysis"/>. This class cannot be instantiated.
    /// </summary>
    /// 
    [Serializable]
    public class PrincipalComponentCollection : ReadOnlyCollection<PrincipalComponent>
    {
        internal PrincipalComponentCollection(PrincipalComponent[] components)
            : base(components) { }
    }
    #endregion

}
